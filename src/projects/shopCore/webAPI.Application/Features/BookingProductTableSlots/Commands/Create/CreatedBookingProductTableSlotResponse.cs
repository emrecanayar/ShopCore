using Core.Application.Responses;

namespace Application.Features.BookingProductTableSlots.Commands.Create;

public class CreatedBookingProductTableSlotResponse : IResponse
{
    public uint Id { get; set; }
    public string PriceType { get; set; }
    public int GuestLimit { get; set; }
    public int Duration { get; set; }
    public int BreakTime { get; set; }
    public int PreventSchedulingBefore { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}