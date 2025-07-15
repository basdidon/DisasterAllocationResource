using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.UpdateRequiredResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/areas/{AreaId}/required-resources/{ResourceId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            // ensure area exists
            var area = await context.AffectedAreas.Include(x => x.RequiredResources)
                .FirstOrDefaultAsync(x => x.AreaId == req.AreaId, ct);
            if(area == null)
            {
                AddError($"Affected Area with ID '{req.AreaId}' was not found.");
                await SendNotFoundAsync(ct);
                return;
            }

            // ensure resource exists in the area
            var existingResource = area.RequiredResources
                .FirstOrDefault(x => x.ResourceId == req.ResourceId);
            if(existingResource == null)
            {
                AddError($"Resource with ID : '{req.ResourceId}' was not found in Affected area with ID '{req.AreaId}'.");
                await SendNotFoundAsync(ct);
                return;
            }

            existingResource.RequiredAmount = req.RequiredAmount;
            
            await context.SaveChangesAsync(ct);

        }
    }
}
