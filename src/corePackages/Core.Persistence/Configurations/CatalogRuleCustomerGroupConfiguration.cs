using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CatalogRuleCustomerGroupConfiguration : BaseConfiguration<CatalogRuleCustomerGroup, uint>
{
    public override void Configure(EntityTypeBuilder<CatalogRuleCustomerGroup> builder)
    {

        builder.Property(crcg => crcg.CatalogRuleId).HasColumnName("CatalogRuleId");
        builder.Property(crcg => crcg.CustomerGroupId).HasColumnName("CustomerGroupId");
        builder.ToTable(TableNameConstants.CATALOG_RULE_CUSTOMER_GROUP);

    }
}