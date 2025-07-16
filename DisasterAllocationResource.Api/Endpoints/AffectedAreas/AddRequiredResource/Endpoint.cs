using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.AddRequiredResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/areas/{AreaId}/required-resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var area = await context.AffectedAreas.Include(x => x.RequiredResources)
                .FirstOrDefaultAsync(x => x.AreaId == x.AreaId, ct);
            if (area == null)
            {
                AddError($"Affected area with ID '{req.AreaId}' was not found.");
                await SendErrorsAsync(404,ct);
                return;
            }

            var existRequiredResource = area.RequiredResources.Any(x => x.ResourceId == req.ResourceId);
            if (existRequiredResource)
            {
                AddError($"Required Resource with ID '{req.ResourceId}' already existing in Affected area with ID : '{req.AreaId}'.");
                await SendErrorsAsync(409, ct);
                return;
            }

            var resource = await context.Resources.FindAsync([req.ResourceId], ct);
            if (resource == null)
            {
                AddError($"Resource with ID '{req.ResourceId}' was not found.");
                await SendErrorsAsync(404, ct);
                return;
            }

            area.RequiredResources.Add(new()
            {
                ResourceId = req.ResourceId,
                RequiredAmount = req.RequiredAmount
            });
            await context.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
