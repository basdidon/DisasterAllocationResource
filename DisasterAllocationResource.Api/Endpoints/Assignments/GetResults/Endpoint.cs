using DisasterAllocationResource.Api.Endpoints.Assignments.Process;
using FastEndpoints;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DisasterAllocationResource.Api.Endpoints.Assignments.GetResults
{
    public class Endpoint(IDistributedCache distributedCache) : EndpointWithoutRequest<IEnumerable<AssignmentDto>>
    {
        public override void Configure()
        {
            Get("/assignments");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var cachedString = await distributedCache.GetStringAsync("assignments", ct);
            if (string.IsNullOrEmpty(cachedString))
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var assignmentDtos = JsonConvert.DeserializeObject<List<AssignmentDto>>(cachedString);
            if (assignmentDtos == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(assignmentDtos, ct);
        }
    }
}
