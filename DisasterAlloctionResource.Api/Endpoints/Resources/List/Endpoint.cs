using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.Resources.List
{
    public class Endpoint(ApplicationDbContext context):EndpointWithoutRequest<IEnumerable<string>>
    {
        public override void Configure()
        {
            Get("/resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var resources= await context.Resources.ToListAsync(ct);
            var resourcesAsList = resources.Select(x => x.ResourceId).ToList();
            await SendOkAsync(resourcesAsList, ct);
        }
    }
}
