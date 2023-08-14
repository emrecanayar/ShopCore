using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartPaymentConfiguration : BaseConfiguration<CartPayment, uint>
{
    public override void Configure(EntityTypeBuilder<CartPayment> builder)
    {

        builder.Property(cp => cp.Method).HasColumnName("Method");
        builder.Property(cp => cp.MethodTitle).HasColumnName("MethodTitle");
        builder.Property(cp => cp.CartId).HasColumnName("CartId");
        builder.ToTable(TableNameConstants.CART_PAYMENT);

    }
}