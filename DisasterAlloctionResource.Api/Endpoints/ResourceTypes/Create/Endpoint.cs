using DisasterAllocationResource.Application.Features.ResourceTypes.Commands;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTypes.Create
{
    public class Request
    {
        public string ResourceId { get; set; } = string.Empty;
    }

    public class Endpoint : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var command = new CreateResourceTypeCommand(req.ResourceId);
            await command.ExecuteAsync(ct);
            await SendOkAsync(ct);
        }
    }
}
