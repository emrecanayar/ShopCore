using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductTableSlot : Entity<uint>
    {
        public string PriceType { get; set; } = null!;
        public int GuestLimit { get; set; }
        public int Duration { get; set; }
        public int BreakTime { get; set; }
        public int PreventSchedulingBefore { get; set; }
        public bool? SameSlotAllDays { get; set; }
        public string? Slots { get; set; }
        public uint BookingProductId { get; set; }

        public BookingProductTableSlot()
        {
            PriceType = string.Empty;
        }

        public BookingProductTableSlot(string priceType, uint bookingProductId)
        {
            PriceType = priceType;
            BookingProductId = bookingProductId;
        }
    }

}
