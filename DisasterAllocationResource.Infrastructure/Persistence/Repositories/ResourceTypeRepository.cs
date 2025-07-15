using DisasterAllocationResource.Application.Interfaces;
using DisasterAllocationResource.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Infrastructure.Persistence.Repositories
{
    internal class ResourceTypeRepository(ApplicationDbContext context) : IResourceRepository
    {
        public async Task CreateAsync(ResourceType resourceType, CancellationToken ct = default)
        {
            await context.ResourceTypes.AddAsync(resourceType, ct);
            await context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<ResourceType>> GetAllAsync(CancellationToken ct = default)
        {
            return await context.ResourceTypes.ToListAsync(ct);
        }

        public async Task<ResourceType?> GetByIdAsync(string resourceTypeId, CancellationToken ct = default)
        {
            return await context.ResourceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ResourceId == resourceTypeId, ct);
        }
    }
}
