using DisasterAllocationResource.Application.Features.AffectedAreas.DTOs;
using DisasterAllocationResource.Application.Features.AffectedAreas.Queries;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.List
{
    public class Endpoint : EndpointWithoutRequest<IEnumerable< AffectedAreaQueryDto>>
    {
        public override void Configure()
        {
            Get("/areas");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var command = new ListAffectedAreasQuery();
            var affectedAreas = await command.ExecuteAsync(ct);
            await SendOkAsync(affectedAreas, ct);
        }
    }
}
