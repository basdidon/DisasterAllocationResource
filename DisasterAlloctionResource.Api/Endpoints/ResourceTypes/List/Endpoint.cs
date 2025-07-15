using DisasterAllocationResource.Application.Features.ResourceTypes.Queries;
using DisasterAllocationResource.Core.Models;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTypes.List
{
    public class Endpoint:EndpointWithoutRequest<IEnumerable<string>>
    {
        public override void Configure()
        {
            Get("/resources");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var command =new ListResourceTypesQuery();

            var resourceTypes = await command.ExecuteAsync(ct);
            var resourceTypesAsList = resourceTypes.Select(x => x.ResourceId).ToList();
            await SendOkAsync(resourceTypesAsList,ct);
        }
    }
}
