using DisasterAllocationResource.Application.Features.AffectedAreas.Commands;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Create
{
    public class Endpoint : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/areas");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var command = new CreateAffectedAreaCommand(req.AreaId,req.UrgencyLevel,req.TimeConstrain);
            await command.ExecuteAsync(ct);
            await SendOkAsync(ct);
        }
    }
}
