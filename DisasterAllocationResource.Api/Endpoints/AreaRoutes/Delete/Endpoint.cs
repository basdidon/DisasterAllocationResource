using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Delete
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/routes/{FromAreaId}/{ToAreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await context.AreaRoutes
                .Where(x =>
                    (x.FromAreaId == req.FromAreaId && x.ToAreaId == req.ToAreaId) ||
                    (x.FromAreaId == req.ToAreaId && x.ToAreaId == req.FromAreaId))
                .ExecuteDeleteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
