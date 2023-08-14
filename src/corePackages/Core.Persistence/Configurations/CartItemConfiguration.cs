using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartItemConfiguration : BaseConfiguration<CartItem, uint>
{
    public override void Configure(EntityTypeBuilder<CartItem> builder)
    {

        builder.Property(ci => ci.Quantity).HasColumnName("Quantity");
        builder.Property(ci => ci.Sku).HasColumnName("Sku");
        builder.Property(ci => ci.Type).HasColumnName("Type");
        builder.Property(ci => ci.Name).HasColumnName("Name");
        builder.Property(ci => ci.CouponCode).HasColumnName("CouponCode");
        builder.Property(ci => ci.Weight).HasColumnName("Weight");
        builder.Property(ci => ci.TotalWeight).HasColumnName("TotalWeight");
        builder.Property(ci => ci.BaseTotalWeight).HasColumnName("BaseTotalWeight");
        builder.Property(ci => ci.Price).HasColumnName("Price");
        builder.Property(ci => ci.BasePrice).HasColumnName("BasePrice");
        builder.Property(ci => ci.Total).HasColumnName("Total");
        builder.Property(ci => ci.BaseTotal).HasColumnName("BaseTotal");
        builder.Property(ci => ci.TaxPercent).HasColumnName("TaxPercent");
        builder.Property(ci => ci.TaxAmount).HasColumnName("TaxAmount");
        builder.Property(ci => ci.BaseTaxAmount).HasColumnName("BaseTaxAmount");
        builder.Property(ci => ci.DiscountPercent).HasColumnName("DiscountPercent");
        builder.Property(ci => ci.DiscountAmount).HasColumnName("DiscountAmount");
        builder.Property(ci => ci.BaseDiscountAmount).HasColumnName("BaseDiscountAmount");
        builder.Property(ci => ci.Additional).HasColumnName("Additional");
        builder.Property(ci => ci.ParentId).HasColumnName("ParentId");
        builder.Property(ci => ci.ProductId).HasColumnName("ProductId");
        builder.Property(ci => ci.CartId).HasColumnName("CartId");
        builder.Property(ci => ci.TaxCategoryId).HasColumnName("TaxCategoryId");
        builder.Property(ci => ci.CustomPrice).HasColumnName("CustomPrice");
        builder.Property(ci => ci.AppliedCartRuleIds).HasColumnName("AppliedCartRuleIds");
        builder.ToTable(TableNameConstants.CART_ITEM);

    }
}