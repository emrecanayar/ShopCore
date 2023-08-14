using Core.Application.Responses;

namespace Application.Features.BookingProductDefaultSlots.Commands.Update;

public class UpdatedBookingProductDefaultSlotResponse : IResponse
{
    public uint Id { get; set; }
    public string BookingType { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}