using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleCouponUsageConfiguration : BaseConfiguration<CartRuleCouponUsage, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleCouponUsage> builder)
    {

        builder.Property(crcu => crcu.TimesUsed).HasColumnName("TimesUsed");
        builder.Property(crcu => crcu.CartRuleCouponId).HasColumnName("CartRuleCouponId");
        builder.Property(crcu => crcu.CustomerId).HasColumnName("CustomerId");
        builder.ToTable(TableNameConstants.CART_RULE_COUPON_USAGE);

    }
}