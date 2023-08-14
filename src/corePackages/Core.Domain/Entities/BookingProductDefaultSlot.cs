using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductDefaultSlot : Entity<uint>
    {
        public string BookingType { get; set; } = null!;
        public int? Duration { get; set; }
        public int? BreakTime { get; set; }
        public string? Slots { get; set; }
        public uint BookingProductId { get; set; }

        public BookingProductDefaultSlot()
        {
            BookingType = string.Empty;
        }

        public BookingProductDefaultSlot(string bookingType, uint bookingProductId)
        {
            BookingType = bookingType;
            BookingProductId = bookingProductId;
        }
    }

}
