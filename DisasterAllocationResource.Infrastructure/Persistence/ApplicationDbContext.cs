using DisasterAllocationResource.Core.Models;
using DisasterAllocationResource.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Infrastructure.Persistence
{
    internal class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ResourceType> ResourceTypes { get; set; }
        //public DbSet<AffectedArea> AffectedAreas { get; set; }
        //public DbSet<ResourceTruck> ResourceTrucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applying all configurations in an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResourceTypeConfiguration).Assembly);
        }
    }
}