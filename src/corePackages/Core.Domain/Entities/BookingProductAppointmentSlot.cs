using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProductAppointmentSlot : Entity<uint>
    {
        public int? Duration { get; set; }
        public int? BreakTime { get; set; }
        public bool? SameSlotAllDays { get; set; }
        public string? Slots { get; set; }
        public uint BookingProductId { get; set; }

        public BookingProductAppointmentSlot()
        {
        }

        public BookingProductAppointmentSlot(uint bookingProductId)
        {
            BookingProductId = bookingProductId;
        }
    }

}
