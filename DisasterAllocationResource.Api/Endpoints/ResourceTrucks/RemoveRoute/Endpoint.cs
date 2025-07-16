using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.RemoveRoute
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/trucks/{TruckId}/routes/{AreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = await context.ResourceTrucks
                .Include(x => x.Routes)
                .FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);

            var routeToRemove = truck?.Routes.FirstOrDefault(x => x.AreaId == req.AreaId);
            if (routeToRemove != null)  
            {
                truck?.Routes.Remove(routeToRemove);
                await context.SaveChangesAsync(ct);
            }

            await SendNoContentAsync(ct);
        }
    }
}
