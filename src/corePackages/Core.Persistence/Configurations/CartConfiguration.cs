using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartConfiguration : BaseConfiguration<Cart, uint>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {

        builder.Property(c => c.CustomerEmail).HasColumnName("CustomerEmail");
        builder.Property(c => c.CustomerFirstName).HasColumnName("CustomerFirstName");
        builder.Property(c => c.CustomerLastName).HasColumnName("CustomerLastName");
        builder.Property(c => c.ShippingMethod).HasColumnName("ShippingMethod");
        builder.Property(c => c.CouponCode).HasColumnName("CouponCode");
        builder.Property(c => c.IsGift).HasColumnName("IsGift");
        builder.Property(c => c.ItemsCount).HasColumnName("ItemsCount");
        builder.Property(c => c.ItemsQty).HasColumnName("ItemsQty");
        builder.Property(c => c.ExchangeRate).HasColumnName("ExchangeRate");
        builder.Property(c => c.GlobalCurrencyCode).HasColumnName("GlobalCurrencyCode");
        builder.Property(c => c.BaseCurrencyCode).HasColumnName("BaseCurrencyCode");
        builder.Property(c => c.ChannelCurrencyCode).HasColumnName("ChannelCurrencyCode");
        builder.Property(c => c.CartCurrencyCode).HasColumnName("CartCurrencyCode");
        builder.Property(c => c.GrandTotal).HasColumnName("GrandTotal");
        builder.Property(c => c.BaseGrandTotal).HasColumnName("BaseGrandTotal");
        builder.Property(c => c.SubTotal).HasColumnName("SubTotal");
        builder.Property(c => c.BaseSubTotal).HasColumnName("BaseSubTotal");
        builder.Property(c => c.TaxTotal).HasColumnName("TaxTotal");
        builder.Property(c => c.BaseTaxTotal).HasColumnName("BaseTaxTotal");
        builder.Property(c => c.DiscountAmount).HasColumnName("DiscountAmount");
        builder.Property(c => c.BaseDiscountAmount).HasColumnName("BaseDiscountAmount");
        builder.Property(c => c.CheckoutMethod).HasColumnName("CheckoutMethod");
        builder.Property(c => c.IsGuest).HasColumnName("IsGuest");
        builder.Property(c => c.IsActive).HasColumnName("IsActive");
        builder.Property(c => c.ConversionTime).HasColumnName("ConversionTime");
        builder.Property(c => c.CustomerId).HasColumnName("CustomerId");
        builder.Property(c => c.ChannelId).HasColumnName("ChannelId");
        builder.Property(c => c.AppliedCartRuleIds).HasColumnName("AppliedCartRuleIds");
        builder.ToTable(TableNameConstants.CART);

    }
}