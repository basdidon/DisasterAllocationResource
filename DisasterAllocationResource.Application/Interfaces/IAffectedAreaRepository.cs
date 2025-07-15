using DisasterAllocationResource.Core.Models;

namespace DisasterAllocationResource.Application.Interfaces
{
    public interface IAffectedAreaRepository
    {
        // Queries
        Task<IEnumerable<AffectedArea>> GetAllAsync(CancellationToken ct = default);
        Task<AffectedArea?> GetByIdAsync(string areaId, CancellationToken ct = default);

        // Mutations
        Task CreateAsync(AffectedArea area, CancellationToken ct = default);
        Task<bool> UpdateAsync(AffectedArea area, CancellationToken ct = default);
        Task<bool> DeleteAsync(string areaId, CancellationToken ct = default);

        // - Required Resources
        Task AddRequiredResourceAsync(string areaId, string resourceTypeId, int amount, CancellationToken ct = default);
        Task UpdateRequiredResourceAsync(string areaId, string resourceTypeId, int amount, CancellationToken ct= default);
        Task DeleteRequiredResourceAsync(string areaId, string resourceTypeId, CancellationToken ct = default);
    }
}
