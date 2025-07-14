using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.UpdateRequiredResource
{
    public class Endpoint:Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/areas/{AreaId}/required-resources");
            AllowAnonymous();
        }

        public override Task HandleAsync(Request req, CancellationToken ct)
        {
            return base.HandleAsync(req, ct);
        }
    }
}
