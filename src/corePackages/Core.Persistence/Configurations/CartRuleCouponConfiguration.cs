using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleCouponConfiguration : BaseConfiguration<CartRuleCoupon, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleCoupon> builder)
    {

        builder.Property(crc => crc.Code).HasColumnName("Code");
        builder.Property(crc => crc.UsageLimit).HasColumnName("UsageLimit");
        builder.Property(crc => crc.UsagePerCustomer).HasColumnName("UsagePerCustomer");
        builder.Property(crc => crc.TimesUsed).HasColumnName("TimesUsed");
        builder.Property(crc => crc.Type).HasColumnName("Type");
        builder.Property(crc => crc.IsPrimary).HasColumnName("IsPrimary");
        builder.Property(crc => crc.ExpiredAt).HasColumnName("ExpiredAt");
        builder.Property(crc => crc.CartRuleId).HasColumnName("CartRuleId");
        builder.ToTable(TableNameConstants.CART_RULE_COUPON);

    }
}