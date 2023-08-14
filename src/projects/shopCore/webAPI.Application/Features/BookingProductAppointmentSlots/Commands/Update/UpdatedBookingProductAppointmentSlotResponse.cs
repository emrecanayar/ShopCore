using Core.Application.Responses;

namespace Application.Features.BookingProductAppointmentSlots.Commands.Update;

public class UpdatedBookingProductAppointmentSlotResponse : IResponse
{
    public uint Id { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}