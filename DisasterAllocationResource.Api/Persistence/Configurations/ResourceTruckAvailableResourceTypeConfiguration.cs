using DisasterAllocationResource.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Api.Persistence.Configurations
{
    internal class ResourceTruckAvailableResourceTypeConfiguration : IEntityTypeConfiguration<ResourceTruckAvailableResource>
    {
        public void Configure(EntityTypeBuilder<ResourceTruckAvailableResource> builder)
        {
            builder.HasKey(x => new { x.TruckId, x.ResourceId });
            builder.HasOne(x => x.Truck)
                .WithMany(x => x.AvailableResources)
                .HasForeignKey(x => x.TruckId);
            builder.HasOne(x => x.ResourceType)
                .WithMany()
                .HasForeignKey(x => x.ResourceId);
        }
    }
}
