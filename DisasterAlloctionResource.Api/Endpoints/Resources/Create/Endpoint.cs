using DisasterAllocationResource.Api.Endpoints.ResourceTypes.Create;
using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.Resources.Create
{

    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var resource = new Resource() { ResourceId = req.ResourceId };
            await context.Resources.AddAsync(resource, ct);
            await context.SaveChangesAsync(ct);
            await SendCreatedAtAsync<GetById.Endpoint>(new { req.ResourceId }, resource, cancellation: ct);
        }
    }
}
