using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Delete
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/areas/{AreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await context.AffectedAreas.Where(x => x.AreaId == req.AreaId)
                .ExecuteDeleteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
