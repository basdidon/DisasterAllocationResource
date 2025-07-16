using DisasterAllocationResource.Api.DTOs.AffectedAreas;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.GetById
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request,AffectedAreaQueryDto>
    {
        public override void Configure()
        {
            Get("/areas/{AreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var area = await context.AffectedAreas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.AreaId == req.AreaId, cancellationToken: ct);

            if(area == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(AffectedAreaQueryDto.Map(area) ,ct);
        }
    }
}
