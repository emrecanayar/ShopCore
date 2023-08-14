using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductRentalSlotConfiguration : BaseConfiguration<BookingProductRentalSlot, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductRentalSlot> builder)
    {

        builder.Property(bprs => bprs.RentingType).HasColumnName("RentingType");
        builder.Property(bprs => bprs.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(bprs => bprs.HourlyPrice).HasColumnName("HourlyPrice");
        builder.Property(bprs => bprs.SameSlotAllDays).HasColumnName("SameSlotAllDays");
        builder.Property(bprs => bprs.Slots).HasColumnName("Slots");
        builder.Property(bprs => bprs.BookingProductId).HasColumnName("BookingProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_RENTAL_SLOT);

    }
}