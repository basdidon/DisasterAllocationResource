using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Update
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/routes/{fromAreaId}/{toAreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var route = await context.AreaRoutes
                .FirstOrDefaultAsync(x =>
                    (x.FromAreaId == req.FromAreaId && x.ToAreaId == req.ToAreaId) ||
                    (x.FromAreaId == req.ToAreaId && x.ToAreaId == req.FromAreaId), ct);

            if (route == null)
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
