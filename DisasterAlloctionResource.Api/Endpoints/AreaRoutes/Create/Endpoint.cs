using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Endpoint:Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/routes/{fromAreaId}/{toAreaId}");
        }

        public override Task HandleAsync(Request req, CancellationToken ct)
        {
            return base.HandleAsync(req, ct);
        }
    }
}
