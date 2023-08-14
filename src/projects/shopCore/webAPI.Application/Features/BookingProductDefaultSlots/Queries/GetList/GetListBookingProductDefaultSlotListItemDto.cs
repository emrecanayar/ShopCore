using Core.Application.Dtos;

namespace Application.Features.BookingProductDefaultSlots.Queries.GetList;

public class GetListBookingProductDefaultSlotListItemDto : IDto
{
    public uint Id { get; set; }
    public string BookingType { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}