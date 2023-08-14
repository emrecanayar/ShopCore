using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CatalogRuleProductConfiguration : BaseConfiguration<CatalogRuleProduct, uint>
{
    public override void Configure(EntityTypeBuilder<CatalogRuleProduct> builder)
    {

        builder.Property(crp => crp.StartsFrom).HasColumnName("StartsFrom");
        builder.Property(crp => crp.EndsTill).HasColumnName("EndsTill");
        builder.Property(crp => crp.EndOtherRules).HasColumnName("EndOtherRules");
        builder.Property(crp => crp.ActionType).HasColumnName("ActionType");
        builder.Property(crp => crp.DiscountAmount).HasColumnName("DiscountAmount");
        builder.Property(crp => crp.SortOrder).HasColumnName("SortOrder");
        builder.Property(crp => crp.ProductId).HasColumnName("ProductId");
        builder.Property(crp => crp.CustomerGroupId).HasColumnName("CustomerGroupId");
        builder.Property(crp => crp.CatalogRuleId).HasColumnName("CatalogRuleId");
        builder.Property(crp => crp.ChannelId).HasColumnName("ChannelId");
        builder.ToTable(TableNameConstants.CATALOG_RULE_PRODUCT);

    }
}