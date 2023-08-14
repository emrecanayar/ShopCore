using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleCustomerGroupConfiguration : BaseConfiguration<CartRuleCustomerGroup, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleCustomerGroup> builder)
    {

        builder.Property(crcg => crcg.CartRuleId).HasColumnName("CartRuleId");
        builder.Property(crcg => crcg.CustomerGroupId).HasColumnName("CustomerGroupId");
        builder.ToTable(TableNameConstants.CART_RULE_CUSTOMER_GROUP);

    }
}