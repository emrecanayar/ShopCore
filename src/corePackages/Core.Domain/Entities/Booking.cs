using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Booking : Entity<uint>
    {
        public int? Qty { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public uint? OrderItemId { get; set; }
        public uint? BookingProductEventTicketId { get; set; }
        public uint? OrderId { get; set; }
        public uint? ProductId { get; set; }

        public Booking()
        {
        }

        public Booking(int? qty, int? from, int? to, uint? orderItemId, uint? bookingProductEventTicketId, uint? orderId, uint? productId)
        {
            Qty = qty;
            From = from;
            To = to;
            OrderItemId = orderItemId;
            BookingProductEventTicketId = bookingProductEventTicketId;
            OrderId = orderId;
            ProductId = productId;
        }
    }

}
