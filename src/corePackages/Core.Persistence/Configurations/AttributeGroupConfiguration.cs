using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeGroupConfiguration : BaseConfiguration<AttributeGroup, uint>
{
    public override void Configure(EntityTypeBuilder<AttributeGroup> builder)
    {

        builder.Property(ag => ag.Name).HasColumnName("Name");
        builder.Property(ag => ag.Position).HasColumnName("Position");
        builder.Property(ag => ag.IsUserDefined).HasColumnName("IsUserDefined");
        builder.Property(ag => ag.AttributeFamilyId).HasColumnName("AttributeFamilyId");
        builder.ToTable(TableNameConstants.ATTRIBUTE_GROUP);

    }
}