using DisasterAllocationResource.Api.DTOs;
using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request,AreaRouteDto>
    {
        public override void Configure()
        {
            Post("/routes/{fromAreaId}/{toAreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var fromArea = await context.AffectedAreas.FirstOrDefaultAsync(x => x.AreaId == req.FromAreaId, ct);
            if (fromArea == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var toArea = await context.AffectedAreas.FirstOrDefaultAsync(x => x.AreaId == req.ToAreaId, ct);
            if (toArea == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var route = new AreaRoute()
            {
                FromArea = fromArea,
                ToArea = toArea,
                TravelTime = req.TravelTime
            };
            await context.AreaRoutes.AddAsync(route, ct);
            await context.SaveChangesAsync(ct);

            await SendOkAsync(AreaRouteDto.Map(route),ct);
        }
    }
}
