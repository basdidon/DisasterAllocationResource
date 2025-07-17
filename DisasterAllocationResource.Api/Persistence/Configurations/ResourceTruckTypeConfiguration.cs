using DisasterAllocationResource.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Api.Persistence.Configurations
{
    internal class ResourceTruckTypeConfiguration : IEntityTypeConfiguration<ResourceTruck>
    {
        public void Configure(EntityTypeBuilder<ResourceTruck> builder)
        {
            builder.HasKey(x => x.TruckId);
            builder.Property(x => x.TruckId).HasMaxLength(50).IsRequired();
        }
    }
}
