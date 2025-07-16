using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.UpdateRoute
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/trucks/{TruckId}/routes");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = await context.ResourceTrucks.Include(x => x.Routes)
                .FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);
            if(truck == null)
            {
                AddError(x=>x.TruckId, $"Resource truck with ID '{req.TruckId}' was not found.");
                await SendErrorsAsync(404, ct);
                return;
            }

            var route = truck.Routes.FirstOrDefault(x => x.AreaId == req.AreaId);
            if(route == null)
            {
                AddError(x=>x.AreaId,$"Route to area with ID '{req.AreaId}' was not found in truck '{req.TruckId}'.");
                await SendErrorsAsync(404, ct);
                return;
            }

            route.TravelTime = req.TravelTime;
            await context.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
