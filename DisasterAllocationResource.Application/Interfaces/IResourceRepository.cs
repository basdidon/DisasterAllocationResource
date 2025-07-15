using DisasterAllocationResource.Core.Models;

namespace DisasterAllocationResource.Application.Interfaces
{
    public interface IResourceRepository
    {
        // Queries
        Task<IEnumerable<ResourceType>> GetAllAsync(CancellationToken ct = default);
        Task<ResourceType?> GetByIdAsync(string resourceTypeId, CancellationToken ct = default);

        // Mutations
        Task CreateAsync(ResourceType resourceType, CancellationToken ct = default);
    }
}
