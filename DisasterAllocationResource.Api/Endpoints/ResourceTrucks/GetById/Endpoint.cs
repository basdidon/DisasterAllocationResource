using DisasterAllocationResource.Api.DTOs.ResourceTrucks;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.GetById
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request, ResourceTruckQueryDto>
    {
        public override void Configure()
        {
            Get("/trucks/{TruckId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var queryable = context.ResourceTrucks.AsQueryable().AsNoTracking();

            if (req.IncludeAvailableResources)
            {
                queryable = queryable.Include(t => t.AvailableResources);
            }

            if (req.IncludeRoutes)
            {
                queryable = queryable.Include(t => t.Routes);
            }

            var truck = await queryable.FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);
            if (truck == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(ResourceTruckQueryDto.Map(truck), ct);
        }
    }
}
