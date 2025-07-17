using DisasterAllocationResource.Api.DTOs.Assignments;
using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DisasterAllocationResource.Api.Endpoints.Assignments.Process
{

    public class Endpoint(ApplicationDbContext context, IDistributedCache distributedCache) : EndpointWithoutRequest<IEnumerable<AssignmentDto>>
    {
        public override void Configure()
        {
            Post("/assignments");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<AssignmentDto> assignments = [];
            var areas = await context.AffectedAreas.AsNoTracking()
                .Include(x => x.RequiredResources)
                .OrderByDescending(x => x.UrgencyLevel)
                .ThenBy(x => x.TimeConstraint)
                .ToListAsync(ct);

            var trucks = await context.ResourceTrucks.AsNoTracking()
                .Include(x => x.AvailableResources)
                .Include(x => x.Routes)
                .ToListAsync(ct);

            foreach (var area in areas)
            {
                ResourceTruck? bestMatchTruck = null;
                int travelTime = int.MaxValue;
                foreach (var truck in trucks)
                {
                    // can the truck reach the area in time?
                    var route = truck.Routes.FirstOrDefault(x => x.AreaId == area.AreaId);
                    if (route == null || route.TravelTime > area.TimeConstraint)
                    {
                        continue;
                    }

                    // does the truck have enough resources?
                    bool sufficientResource = area.RequiredResources.All(required => truck.AvailableResources
                            .Any(x => x.ResourceId == required.ResourceId && x.AvailableAmount >= required.RequiredAmount));

                    if (!sufficientResource)
                    {
                        continue;
                    }

                    // set best match truck if it's the first one or has a shorter travel time
                    if (bestMatchTruck == null || travelTime > route.TravelTime)
                    {
                        bestMatchTruck = truck;
                        travelTime = route.TravelTime;
                    }
                }

                if (bestMatchTruck == null)
                {
                    AddError($"no truck match with conditions on Area with ID : '{area.AreaId}'");
                    await SendErrorsAsync(500, ct);
                    return;
                }

                trucks.Remove(bestMatchTruck);
                assignments.Add(new AssignmentDto
                {
                    AreaId = area.AreaId,
                    TruckId = bestMatchTruck.TruckId,
                    TravelTime = travelTime,
                    DeliveredResources = area.RequiredResources.Select(x => new DeliveredResourcesDto
                    {
                        ResourceId = x.ResourceId,
                        DeliveredAmount = x.RequiredAmount
                    })
                });
            }

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };
            await distributedCache.SetStringAsync("assignments", JsonConvert.SerializeObject(assignments, Formatting.Indented), options, ct);
            await SendOkAsync(assignments, ct);
        }
    }
}
