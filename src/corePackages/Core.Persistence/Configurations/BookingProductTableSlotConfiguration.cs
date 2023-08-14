using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductTableSlotConfiguration : BaseConfiguration<BookingProductTableSlot, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductTableSlot> builder)
    {

        builder.Property(bpts => bpts.PriceType).HasColumnName("PriceType");
        builder.Property(bpts => bpts.GuestLimit).HasColumnName("GuestLimit");
        builder.Property(bpts => bpts.Duration).HasColumnName("Duration");
        builder.Property(bpts => bpts.BreakTime).HasColumnName("BreakTime");
        builder.Property(bpts => bpts.PreventSchedulingBefore).HasColumnName("PreventSchedulingBefore");
        builder.Property(bpts => bpts.SameSlotAllDays).HasColumnName("SameSlotAllDays");
        builder.Property(bpts => bpts.Slots).HasColumnName("Slots");
        builder.Property(bpts => bpts.BookingProductId).HasColumnName("BookingProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_TABLE_SLOT);

    }
}