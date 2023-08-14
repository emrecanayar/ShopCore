using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductEventTicket : Entity<uint>
    {
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTime? SpecialPriceFrom { get; set; }
        public DateTime? SpecialPriceTo { get; set; }
        public uint BookingProductId { get; set; }

        public BookingProductEventTicket()
        {
        }

        public BookingProductEventTicket(uint bookingProductId)
        {
            BookingProductId = bookingProductId;
        }
    }

}
