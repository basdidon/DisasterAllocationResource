using DisasterAllocationResource.Application.Features.AffectedAreas.Commands;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.AddRequiredResource
{
    public class Endpoint:Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/areas/{AreaId}/required-resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var command = new AddRequiredResourceCommand(req.AreaId, req.ResourceId, req.RequiredAmount);
            await command.ExecuteAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
