using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeFamilyConfiguration : BaseConfiguration<AttributeFamily, uint>
{
    public override void Configure(EntityTypeBuilder<AttributeFamily> builder)
    {

        builder.Property(af => af.Code).HasColumnName("Code");
        builder.Property(af => af.Name).HasColumnName("Name");
        builder.Property(af => af.Status).HasColumnName("Status");
        builder.Property(af => af.IsUserDefined).HasColumnName("IsUserDefined");
        builder.ToTable(TableNameConstants.ATTRIBUTE_FAMILY);

    }
}