using DisasterAllocationResource.Api.DTOs.AffectedAreas.v2;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.GetById.v2
{
    public class Endpoint(ApplicationDbContext context): Endpoint<Request,AffectedAreaQueryDtoV2>
    {
        public override void Configure()
        {
            Get("/areas/{AreaId}");
            Version(2);
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var queryable = context.AffectedAreas
                .AsQueryable()
                .AsNoTracking();

            if (req.IncludeRequiredResources)
            {
                queryable = queryable.Include(x => x.RequiredResources);
            }

            if (req.IncludeMappedArea)
            {
                queryable = queryable.Include(x => x.RoutesFrom)
                    .Include(x => x.RoutesTo);
            }


            var area = await queryable.FirstOrDefaultAsync(x=>x.AreaId == req.AreaId,ct);
            if(area == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(AffectedAreaQueryDtoV2.Map(area), ct);
        }
    }
}
