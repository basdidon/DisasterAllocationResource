using DisasterAllocationResource.Api.DTOs;
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
                .FirstOrDefaultAsync(x => x.AreaId == req.AreaId);

            if(area == null)
            {
                AddError($"Affected area with ID : '{req.AreaId}' was not found.");
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(AffectedAreaQueryDto.Map(area) ,ct);
        }
    }
}
