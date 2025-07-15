using DisasterAllocationResource.Application.Features.AffectedAreas.Commands;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Update
{
    public class Endpoint:Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/areas/{AreaId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var command = new UpdateAffectedAreaCommand(req.AreaId, req.UrgencyLevel, req.TimeConstraint);
            var success = await command.ExecuteAsync(ct);
            if (!success)
            {
                await SendNotFoundAsync(ct);
            }
            else
            {
                await SendNoContentAsync(ct);
            }
        }
    }
}
