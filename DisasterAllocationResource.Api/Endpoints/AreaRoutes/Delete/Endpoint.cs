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
            await context.AreaRoutes.Where(x => x.FromArea.AreaId == req.FromAreaId && x.ToArea.AreaId == req.ToAreaId)
                .ExecuteDeleteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
