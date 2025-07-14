using DisasterAllocationResource.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterAllocationResource.Infrastructure.Persistence.Configurations
{
    internal class ResourceTypeConfiguration : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.HasKey(x => x.ResourceId);
        }
    }
}
