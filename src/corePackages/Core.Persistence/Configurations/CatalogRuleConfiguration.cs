using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CatalogRuleConfiguration : BaseConfiguration<CatalogRule, uint>
{
    public override void Configure(EntityTypeBuilder<CatalogRule> builder)
    {

        builder.Property(cr => cr.Name).HasColumnName("Name");
        builder.Property(cr => cr.Description).HasColumnName("Description");
        builder.Property(cr => cr.StartsFrom).HasColumnName("StartsFrom");
        builder.Property(cr => cr.EndsTill).HasColumnName("EndsTill");
        builder.Property(cr => cr.Status).HasColumnName("Status");
        builder.Property(cr => cr.ConditionType).HasColumnName("ConditionType");
        builder.Property(cr => cr.Conditions).HasColumnName("Conditions");
        builder.Property(cr => cr.EndOtherRules).HasColumnName("EndOtherRules");
        builder.Property(cr => cr.ActionType).HasColumnName("ActionType");
        builder.Property(cr => cr.DiscountAmount).HasColumnName("DiscountAmount");
        builder.Property(cr => cr.SortOrder).HasColumnName("SortOrder");
        builder.ToTable(TableNameConstants.CATALOG_RULE);

    }
}