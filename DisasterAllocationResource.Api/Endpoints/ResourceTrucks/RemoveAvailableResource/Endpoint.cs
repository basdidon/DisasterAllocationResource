using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.RemoveAvailableResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/trucks/{TruckId}/available-resources/{ResourceId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = await context.ResourceTrucks
                .Include(x => x.AvailableResources)
                .FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);

            var resourceToRemove = truck?.AvailableResources.FirstOrDefault(x => x.ResourceId == req.ResourceId);
            if (resourceToRemove != null)
            {
                truck?.AvailableResources.Remove(resourceToRemove);
                await context.SaveChangesAsync(ct);
            }

            await SendNoContentAsync(ct);
        }
    }
}
