using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AttributeOptionTranslationConfiguration : BaseConfiguration<AttributeOptionTranslation, uint>
{
    public override void Configure(EntityTypeBuilder<AttributeOptionTranslation> builder)
    {

        builder.Property(aot => aot.Locale).HasColumnName("Locale");
        builder.Property(aot => aot.Label).HasColumnName("Label");
        builder.Property(aot => aot.AttributeOptionId).HasColumnName("AttributeOptionId");
        builder.ToTable(TableNameConstants.ATTRIBUTE_OPTION_TRANSLATION);

    }
}