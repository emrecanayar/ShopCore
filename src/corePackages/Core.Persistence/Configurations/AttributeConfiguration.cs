using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeConfiguration : BaseConfiguration<Core.Domain.Entities.Attribute, uint>
{
    public override void Configure(EntityTypeBuilder<Core.Domain.Entities.Attribute> builder)
    {

        builder.Property(a => a.Code).HasColumnName("Code");
        builder.Property(a => a.AdminName).HasColumnName("AdminName");
        builder.Property(a => a.Type).HasColumnName("Type");
        builder.Property(a => a.Validation).HasColumnName("Validation");
        builder.Property(a => a.Position).HasColumnName("Position");
        builder.Property(a => a.IsRequired).HasColumnName("IsRequired");
        builder.Property(a => a.IsUnique).HasColumnName("IsUnique");
        builder.Property(a => a.ValuePerLocale).HasColumnName("ValuePerLocale");
        builder.Property(a => a.ValuePerChannel).HasColumnName("ValuePerChannel");
        builder.Property(a => a.IsFilterable).HasColumnName("IsFilterable");
        builder.Property(a => a.IsConfigurable).HasColumnName("IsConfigurable");
        builder.Property(a => a.IsUserDefined).HasColumnName("IsUserDefined");
        builder.Property(a => a.IsVisibleOnFront).HasColumnName("IsVisibleOnFront");
        builder.Property(a => a.SwatchType).HasColumnName("SwatchType");
        builder.Property(a => a.UseInFlat).HasColumnName("UseInFlat");
        builder.Property(a => a.IsComparable).HasColumnName("IsComparable");
        builder.Property(a => a.EnableWysiwyg).HasColumnName("EnableWysiwyg");
        builder.ToTable(TableNameConstants.ATTRIBUTE);

    }
}