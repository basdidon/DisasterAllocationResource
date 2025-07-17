using DisasterAllocationResource.Api.DTOs.AffectedAreas.v2;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.List.v2
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request, IEnumerable<AffectedAreaQueryDtoV2>>
    {
        public override void Configure()
        {
            Get("/areas");
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
                    .Include(x=>x.RoutesTo);
            }


            var areas = await queryable.ToListAsync(ct);
            var areasAsDto = areas.Select(area => AffectedAreaQueryDtoV2.Map(area));
            await SendOkAsync(areasAsDto, ct);
        }

    }
}
