using DisasterAllocationResource.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Infrastructure.Persistence.Configurations
{
    internal class AffectedAreaTypeConfiguration : IEntityTypeConfiguration<AffectedArea>
    {
        public void Configure(EntityTypeBuilder<AffectedArea> builder)
        {
            builder.HasKey(x => x.AreaId);
            builder.Property(x => x.AreaId).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UrgencyLevel).IsRequired();
            builder.Property(x => x.TimeConstraint).IsRequired();


            builder.HasMany(x => x.MappedArea)
                .WithMany()
                .UsingEntity<AreaRoute>(
                    r => r.HasOne(x=>x.ToArea).WithMany(),
                    l => l.HasOne(x=>x.FromArea).WithMany()
                );
        }
    }
}
