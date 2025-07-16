using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.RemoveRequiredResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/areas/{AreaId}/required-resources/{ResourceId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var area = await context.AffectedAreas.Include(x => x.RequiredResources)
                .FirstOrDefaultAsync(x => x.AreaId == req.AreaId, ct);

            var resource = area?.RequiredResources.FirstOrDefault(x => x.ResourceId == req.ResourceId);

            if (resource != null)
            {
                area?.RequiredResources.Remove(resource);
                await context.SaveChangesAsync(ct);
            }

            await SendNoContentAsync(ct);

        }
    }
}
