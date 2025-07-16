using DisasterAllocationResource.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Api.Persistence.Configurations
{
    public class AreaRouteTypeConfiguration : IEntityTypeConfiguration<AreaRoute>
    {
        public void Configure(EntityTypeBuilder<AreaRoute> builder)
        {
            builder.HasKey(x => new { x.FromAreaId, x.ToAreaId });
            builder.HasOne(x => x.FromArea)
                .WithMany(x => x.RoutesFrom)
                .HasForeignKey(x => x.FromAreaId);

            builder.HasOne(x => x.ToArea)
                .WithMany(x => x.RoutesTo)
                .HasForeignKey(x => x.ToAreaId);
        }
    }
}
