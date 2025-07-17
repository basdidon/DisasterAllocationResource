using DisasterAllocationResource.Api.DTOs.ResourceTrucks;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.List
{

    public class Endpoint(ApplicationDbContext context) : Endpoint<Request,IEnumerable<ResourceTruckQueryDto>>
    {
        public override void Configure()
        {
            Get("/trucks");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var queryable = context.ResourceTrucks
                .AsQueryable()
                .AsNoTracking();

            if (req.IncludeAvailableResources)
            {
                queryable = queryable.Include(t => t.AvailableResources);
            }

            if (req.IncludeRoutes)
            {
                queryable = queryable.Include(t => t.Routes);
            }

            var trucks = await queryable.ToListAsync(ct);
            var truckDtos = trucks.Select(ResourceTruckQueryDto.Map);
            await SendOkAsync(truckDtos, ct);
        }
    }
}
