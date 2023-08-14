using Core.Application.Dtos;

namespace Application.Features.BookingProductAppointmentSlots.Queries.GetList;

public class GetListBookingProductAppointmentSlotListItemDto : IDto
{
    public uint Id { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}