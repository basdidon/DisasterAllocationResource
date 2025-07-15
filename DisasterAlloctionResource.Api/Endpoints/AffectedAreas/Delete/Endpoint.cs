using DisasterAllocationResource.Application.Features.AffectedAreas.Commands;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Delete
{
    public class Endpoint : Endpoint<Request>
    {
        public override void Configure()
        {
            Delete("/areas/{AreaId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var command = new DeleteAffectedAreaCommand(req.AreaId);
            await command.ExecuteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
