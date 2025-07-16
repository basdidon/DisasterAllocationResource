using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.Delete
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/trucks/{TruckId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await context.ResourceTrucks.Where(t => t.TruckId == req.TruckId)
                .ExecuteDeleteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
