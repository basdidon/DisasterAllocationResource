using DisasterAllocationResource.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Api.Persistence.Configurations
{
    internal class AffectedAreaRequiredResourceTypeConfiguration : IEntityTypeConfiguration<AffectedAreaRequiredResource>
    {
        public void Configure(EntityTypeBuilder<AffectedAreaRequiredResource> builder)
        {
            builder.HasKey(x => new { x.AreaId, x.ResourceId });

            builder.HasOne(x => x.AffectedArea)
                .WithMany(x => x.RequiredResources);

            builder.HasOne(x => x.ResourceType)
                .WithMany();
        }
    }
}
