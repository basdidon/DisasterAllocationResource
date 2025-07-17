
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.UpdateAvailableResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/trucks/{TruckId}/available-resources/{ResourceId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = await context.ResourceTrucks.Include(x => x.AvailableResources)
                 .FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);
            if (truck == null)
            {
                AddError(x=>x.TruckId,$"Resource truck with ID '{req.TruckId}' was not found.");
                await SendErrorsAsync(404,ct);
                return;
            }

            var resource = truck.AvailableResources.FirstOrDefault(x => x.ResourceId == req.ResourceId);
            if (resource == null)
            {
                AddError(x=>x.ResourceId,$"Resource with ID '{req.ResourceId}' was not found in truck '{req.TruckId}'.");
                await SendErrorsAsync(404, ct);
                return;
            }

            resource.AvailableAmount = req.AvailableAmount;
            await context.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
