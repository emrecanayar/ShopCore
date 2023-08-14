using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeOptionConfiguration : BaseConfiguration<AttributeOption, uint>
{
    public override void Configure(EntityTypeBuilder<AttributeOption> builder)
    {

        builder.Property(ao => ao.AdminName).HasColumnName("AdminName");
        builder.Property(ao => ao.SortOrder).HasColumnName("SortOrder");
        builder.Property(ao => ao.AttributeId).HasColumnName("AttributeId");
        builder.Property(ao => ao.SwatchValue).HasColumnName("SwatchValue");
        builder.ToTable(TableNameConstants.ATTRIBUTE_OPTION);

    }
}