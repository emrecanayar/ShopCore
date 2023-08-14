using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeGroupMappingConfiguration : BaseConfiguration<AttributeGroupMapping, uint>
{
    public override void Configure(EntityTypeBuilder<AttributeGroupMapping> builder)
    {

        builder.Property(agm => agm.AttributeId).HasColumnName("AttributeId");
        builder.Property(agm => agm.AttributeGroupId).HasColumnName("AttributeGroupId");
        builder.Property(agm => agm.Position).HasColumnName("Position");
        builder.ToTable(TableNameConstants.ATTRIBUTE_GROUP_MAPPING);

    }
}