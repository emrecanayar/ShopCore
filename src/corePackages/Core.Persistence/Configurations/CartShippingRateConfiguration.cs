using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartShippingRateConfiguration : BaseConfiguration<CartShippingRate, uint>
{
    public override void Configure(EntityTypeBuilder<CartShippingRate> builder)
    {

        builder.Property(csr => csr.Carrier).HasColumnName("Carrier");
        builder.Property(csr => csr.CarrierTitle).HasColumnName("CarrierTitle");
        builder.Property(csr => csr.Method).HasColumnName("Method");
        builder.Property(csr => csr.MethodTitle).HasColumnName("MethodTitle");
        builder.Property(csr => csr.MethodDescription).HasColumnName("MethodDescription");
        builder.Property(csr => csr.Price).HasColumnName("Price");
        builder.Property(csr => csr.BasePrice).HasColumnName("BasePrice");
        builder.Property(csr => csr.CartAddressId).HasColumnName("CartAddressId");
        builder.Property(csr => csr.DiscountAmount).HasColumnName("DiscountAmount");
        builder.Property(csr => csr.BaseDiscountAmount).HasColumnName("BaseDiscountAmount");
        builder.Property(csr => csr.IsCalculateTax).HasColumnName("IsCalculateTax");
        builder.ToTable(TableNameConstants.CART_SHIPPING_RATE);

    }
}