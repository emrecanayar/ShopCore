using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductAppointmentSlotConfiguration : BaseConfiguration<BookingProductAppointmentSlot, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductAppointmentSlot> builder)
    {

        builder.Property(bpas => bpas.Duration).HasColumnName("Duration");
        builder.Property(bpas => bpas.BreakTime).HasColumnName("BreakTime");
        builder.Property(bpas => bpas.SameSlotAllDays).HasColumnName("SameSlotAllDays");
        builder.Property(bpas => bpas.Slots).HasColumnName("Slots");
        builder.Property(bpas => bpas.BookingProductId).HasColumnName("BookingProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_APPOINTMENT_SLOT);

    }
}