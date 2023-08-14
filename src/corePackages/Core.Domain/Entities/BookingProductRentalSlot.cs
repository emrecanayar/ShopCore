using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductRentalSlot : Entity<uint>
    {
        public string RentingType { get; set; } = null!;
        public decimal? DailyPrice { get; set; }
        public decimal? HourlyPrice { get; set; }
        public bool? SameSlotAllDays { get; set; }
        public string? Slots { get; set; }
        public uint BookingProductId { get; set; }

        public BookingProductRentalSlot()
        {
            RentingType = string.Empty;
        }

        public BookingProductRentalSlot(string rentingType, uint bookingProductId)
        {
            RentingType = rentingType;
            BookingProductId = bookingProductId;
        }
    }

}
