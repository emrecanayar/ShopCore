using Core.Application.Responses;

namespace Application.Features.Bookings.Queries.GetById;

public class GetByIdBookingResponse : IResponse
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