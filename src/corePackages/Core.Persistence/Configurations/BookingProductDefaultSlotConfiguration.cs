using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductDefaultSlotConfiguration : BaseConfiguration<BookingProductDefaultSlot, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductDefaultSlot> builder)
    {

        builder.Property(bpds => bpds.BookingType).HasColumnName("BookingType");
        builder.Property(bpds => bpds.Duration).HasColumnName("Duration");
        builder.Property(bpds => bpds.BreakTime).HasColumnName("BreakTime");
        builder.Property(bpds => bpds.Slots).HasColumnName("Slots");
        builder.Property(bpds => bpds.BookingProductId).HasColumnName("BookingProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_DEFAULT_SLOT);

    }
}