using FastEndpoints;
using DisasterAllocationResource.Api.DTOs;
using DisasterAllocationResource.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.List
{
    public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<IEnumerable< AffectedAreaQueryDto>>
    {
        public override void Configure()
        {
            Get("/areas");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var areas = await context.AffectedAreas.Include(x=>x.RequiredResources)
                .ToListAsync(ct);
            var dto = areas.Select(x => AffectedAreaQueryDto.Map(x));
            await SendOkAsync(dto, ct);
        }
    }
}
