using Core.Application.Responses;

namespace Application.Features.Bookings.Commands.Update;

public class UpdatedBookingResponse : IResponse
{
    public uint Id { get; set; }
    public int? Qty { get; set; }
    public int? From { get; set; }
    public int? To { get; set; }
    public uint? OrderItemId { get; set; }
    public uint? BookingProductEventTicketId { get; set; }
    public uint? OrderId { get; set; }
    public uint? ProductId { get; set; }
}