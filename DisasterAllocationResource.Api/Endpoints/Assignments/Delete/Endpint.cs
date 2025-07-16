using FastEndpoints;
using Microsoft.Extensions.Caching.Distributed;

namespace DisasterAllocationResource.Api.Endpoints.Assignments.Delete
{
    public class Endpint(IDistributedCache distributedCache):EndpointWithoutRequest
    {
        public override void Configure()
        {
            Delete("/assignments");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await distributedCache.RemoveAsync("assignments", ct);
            await SendNoContentAsync(ct);
        }
    }
}
