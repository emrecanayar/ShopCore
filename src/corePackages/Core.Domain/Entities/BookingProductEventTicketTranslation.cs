using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductEventTicketTranslation : Entity<uint>
    {
        public string Locale { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }

        public BookingProductEventTicketTranslation()
        {
            Locale = string.Empty;
        }

        public BookingProductEventTicketTranslation(string locale)
        {
            Locale = locale;
        }
    }

}
