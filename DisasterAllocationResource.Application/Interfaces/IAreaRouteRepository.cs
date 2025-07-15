using DisasterAllocationResource.Core.Models;

namespace DisasterAllocationResource.Application.Interfaces
{
    public interface IAreaRouteRepository
    {
        // Queries
        Task<IEnumerable<AreaRoute>> GetAllAsync(CancellationToken ct = default);
        Task<AreaRoute?> GetAreaByIdsAsync(string areaId, string toArea, CancellationToken ct = default);
        Task<IEnumerable< AreaRoute>> GetAreaByIdAsync(string areaId, CancellationToken ct = default);
        // Mutations
        Task CreateAsync(AreaRoute routeTravelTime, CancellationToken ct = default);
        Task UpdateAsync(AreaRoute routeTravelTime, CancellationToken ct = default);
        Task DeleteAsync(string areaId, string toArea, CancellationToken ct = default);
    }
}
