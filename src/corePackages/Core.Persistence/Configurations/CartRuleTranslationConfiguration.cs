using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleTranslationConfiguration : BaseConfiguration<CartRuleTranslation, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleTranslation> builder)
    {

        builder.Property(crt => crt.Locale).HasColumnName("Locale");
        builder.Property(crt => crt.Label).HasColumnName("Label");
        builder.Property(crt => crt.CartRuleId).HasColumnName("CartRuleId");
        builder.ToTable(TableNameConstants.CART_RULE_TRANSLATION);

    }
}