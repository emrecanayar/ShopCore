using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductConfiguration : BaseConfiguration<BookingProduct, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProduct> builder)
    {

        builder.Property(bp => bp.Type).HasColumnName("Type");
        builder.Property(bp => bp.Qty).HasColumnName("Qty");
        builder.Property(bp => bp.Location).HasColumnName("Location");
        builder.Property(bp => bp.ShowLocation).HasColumnName("ShowLocation");
        builder.Property(bp => bp.AvailableEveryWeek).HasColumnName("AvailableEveryWeek");
        builder.Property(bp => bp.AvailableFrom).HasColumnName("AvailableFrom");
        builder.Property(bp => bp.AvailableTo).HasColumnName("AvailableTo");
        builder.Property(bp => bp.ProductId).HasColumnName("ProductId");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT);

    }
}