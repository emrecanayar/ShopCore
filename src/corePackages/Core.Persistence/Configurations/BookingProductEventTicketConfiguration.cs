using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductEventTicketConfiguration : BaseConfiguration<BookingProductEventTicket, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductEventTicket> builder)
    {

        builder.Property(bpet => bpet.Price).HasColumnName("Price");
        builder.Property(bpet => bpet.Qty).HasColumnName("Qty");
        builder.Property(bpet => bpet.SpecialPrice).HasColumnName("SpecialPrice");
        builder.Property(bpet => bpet.SpecialPriceFrom).HasColumnName("SpecialPriceFrom");
        builder.Property(bpet => bpet.SpecialPriceTo).HasColumnName("SpecialPriceTo");
        builder.Property(bpet => bpet.BookingProductId).HasColumnName("BookingProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_EVENT_TICKET);

    }
}