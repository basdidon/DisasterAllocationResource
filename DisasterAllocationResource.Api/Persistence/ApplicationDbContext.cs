using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Persistence
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AffectedArea> AffectedAreas { get; set; }
        public DbSet<AreaRoute> AreaRoutes { get; set; }
        public DbSet<ResourceTruck> ResourceTrucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applying all configurations in an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResourceTypeConfiguration).Assembly);
        }
    }
}