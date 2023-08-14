using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CatalogRuleProductPriceConfiguration : BaseConfiguration<CatalogRuleProductPrice, uint>
{
    public override void Configure(EntityTypeBuilder<CatalogRuleProductPrice> builder)
    {

        builder.Property(crpp => crpp.Price).HasColumnName("Price");
        builder.Property(crpp => crpp.RuleDate).HasColumnName("RuleDate");
        builder.Property(crpp => crpp.StartsFrom).HasColumnName("StartsFrom");
        builder.Property(crpp => crpp.EndsTill).HasColumnName("EndsTill");
        builder.Property(crpp => crpp.ProductId).HasColumnName("ProductId");
        builder.Property(crpp => crpp.CustomerGroupId).HasColumnName("CustomerGroupId");
        builder.Property(crpp => crpp.CatalogRuleId).HasColumnName("CatalogRuleId");
        builder.Property(crpp => crpp.ChannelId).HasColumnName("ChannelId");
        builder.ToTable(TableNameConstants.CATALOG_RULE_PRODUCT_PRICE);

    }
}