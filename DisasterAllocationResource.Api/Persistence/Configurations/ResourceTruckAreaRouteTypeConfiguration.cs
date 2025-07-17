using DisasterAllocationResource.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Api.Persistence.Configurations
{
    internal class ResourceTruckAreaRouteTypeConfiguration : IEntityTypeConfiguration<ResourceTruckAreaRoute>
    {
        public void Configure(EntityTypeBuilder<ResourceTruckAreaRoute> builder)
        {
            builder.HasKey(x => new { x.TruckId, x.AreaId });
            builder.HasOne(x => x.Truck)
                .WithMany(x=>x.Routes)
                .HasForeignKey(x => x.TruckId);
            builder.HasOne(x=> x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId);
        }
    }
}
