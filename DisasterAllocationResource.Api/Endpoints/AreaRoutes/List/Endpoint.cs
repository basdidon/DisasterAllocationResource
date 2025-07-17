using DisasterAllocationResource.Api.DTOs;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.List
{
    public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<IEnumerable<AreaRouteDto>>
    {
        public override void Configure()
        {
            Get("/routes");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var routes = await context.AreaRoutes.ToListAsync(ct);
            var routesAsDto = routes.Select(x => AreaRouteDto.Map(x));
            await SendOkAsync(routesAsDto, ct);
        }
    }
}
