using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingConfiguration : BaseConfiguration<Booking, uint>
{
    public override void Configure(EntityTypeBuilder<Booking> builder)
    {

        builder.Property(b => b.Qty).HasColumnName("Qty");
        builder.Property(b => b.From).HasColumnName("From");
        builder.Property(b => b.To).HasColumnName("To");
        builder.Property(b => b.OrderItemId).HasColumnName("OrderItemId");
        builder.Property(b => b.BookingProductEventTicketId).HasColumnName("BookingProductEventTicketId");
        builder.Property(b => b.OrderId).HasColumnName("OrderId");
        builder.Property(b => b.ProductId).HasColumnName("ProductId");
        builder.ToTable(TableNameConstants.BOOKING);

    }
}