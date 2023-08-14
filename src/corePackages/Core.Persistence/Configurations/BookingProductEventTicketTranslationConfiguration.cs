using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class BookingProductEventTicketTranslationConfiguration : BaseConfiguration<BookingProductEventTicketTranslation, uint>
{
    public override void Configure(EntityTypeBuilder<BookingProductEventTicketTranslation> builder)
    {

        builder.Property(bpett => bpett.Locale).HasColumnName("Locale");
        builder.Property(bpett => bpett.Name).HasColumnName("Name");
        builder.Property(bpett => bpett.Description).HasColumnName("Description");
        builder.ToTable(TableNameConstants.BOOKING_PRODUCT_EVENT_TICKET_TRANSLATION);

    }
}