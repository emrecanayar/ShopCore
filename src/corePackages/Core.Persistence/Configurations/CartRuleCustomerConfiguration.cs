using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleCustomerConfiguration : BaseConfiguration<CartRuleCustomer, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleCustomer> builder)
    {

        builder.Property(crc => crc.TimesUsed).HasColumnName("TimesUsed");
        builder.Property(crc => crc.CartRuleId).HasColumnName("CartRuleId");
        builder.Property(crc => crc.CustomerId).HasColumnName("CustomerId");
        builder.ToTable(TableNameConstants.CART_RULE_CUSTOMER);

    }
}