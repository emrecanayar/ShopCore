using Core.Application.Dtos;

namespace Application.Features.BookingProductRentalSlots.Queries.GetList;

public class GetListBookingProductRentalSlotListItemDto : IDto
{
    public uint Id { get; set; }
    public string RentingType { get; set; }
    public decimal? DailyPrice { get; set; }
    public decimal? HourlyPrice { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}