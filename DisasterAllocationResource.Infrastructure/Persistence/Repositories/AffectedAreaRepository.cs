using DisasterAllocationResource.Application.Interfaces;
using DisasterAllocationResource.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterAllocationResource.Infrastructure.Persistence.Repositories
{
    class AffectedAreaRepository(ApplicationDbContext context) : IAffectedAreaRepository
    {
        // Queries
        public async Task<IEnumerable<AffectedArea>> GetAllAsync(CancellationToken ct = default)
        {
            return await context.AffectedAreas.AsNoTracking()
                .Include(x => x.RequiredResources)
                .Include(x => x.MappedArea)
                .ToListAsync(ct);
        }

        public async Task<AffectedArea?> GetByIdAsync(string areaId, CancellationToken ct = default)
        {
            return await context.AffectedAreas.AsNoTracking()
                .Include(x => x.RequiredResources)
                .Include(x => x.MappedArea)
                .FirstOrDefaultAsync(x => x.AreaId == areaId, ct);
        }

        // Mutations
        public async Task CreateAsync(AffectedArea area, CancellationToken ct = default)
        {
            await context.AffectedAreas.AddAsync(area, ct);
            await context.SaveChangesAsync(ct);
        }

        public async Task<bool> UpdateAsync(AffectedArea area, CancellationToken ct = default)
        {
            return await context.AffectedAreas
                .Where(x => x.AreaId == area.AreaId)
                .ExecuteUpdateAsync(upd => upd
                    .SetProperty(x => x.UrgencyLevel, area.UrgencyLevel)
                    .SetProperty(x => x.TimeConstraint, area.TimeConstraint), ct) > 0;
        }

        public async Task<bool> DeleteAsync(string areaId, CancellationToken ct = default)
        {
            return await context.AffectedAreas
                .Where(x => x.AreaId == areaId)
                .ExecuteDeleteAsync(ct) > 0;
        }

        // - Required Resources
        public async Task AddRequiredResourceAsync(string areaId, string resourceTypeId, int amount, CancellationToken ct = default)
        {
            var requiredResource = new AffectedAreaRequiredResource
            {
                AreaId = areaId,
                ResourceId = resourceTypeId,
                RequiredAmount = amount,
            };

            await context.AffectedAreaRequiredResources.AddAsync(requiredResource, ct);

        }
        public Task UpdateRequiredResourceAsync(string areaId, string resourceTypeId, int amount, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRequiredResourceAsync(string areaId, string resourceTypeId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }






    }
}
