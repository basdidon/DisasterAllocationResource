using DisasterAllocationResource.Api.DTOs;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.List.v2
{
    public class Request
    {
        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeRequiredResources { get; set; }

        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeMappedArea { get; set; }
    }

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
