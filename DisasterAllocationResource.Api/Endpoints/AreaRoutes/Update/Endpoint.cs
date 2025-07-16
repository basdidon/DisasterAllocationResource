using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Update
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/routes/{fromAreaId}/{toAreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var route = await context.AreaRoutes.FindAsync([req.FromAreaId, req.ToAreaId ], ct);
            if(route == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            route.TravelTime = req.TravelTime;
            await context.SaveChangesAsync(ct);

            await SendOkAsync(ct);
        }
    }
}
