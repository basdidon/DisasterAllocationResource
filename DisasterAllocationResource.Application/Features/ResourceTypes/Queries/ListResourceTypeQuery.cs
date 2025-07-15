using DisasterAllocationResource.Application.Interfaces;
using DisasterAllocationResource.Core.Models;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.ResourceTypes.Queries
{
    public record ListResourceTypesQuery(): ICommand<IEnumerable<ResourceType>>;

    internal class ListResourceTypesQueryHandler(IResourceRepository resourceTypeRepo) : ICommandHandler<ListResourceTypesQuery, IEnumerable<ResourceType>>
    {
        public async Task<IEnumerable<ResourceType>> ExecuteAsync(ListResourceTypesQuery command, CancellationToken ct)
        {
            return await resourceTypeRepo.GetAllAsync(ct);
        }
    }
}
