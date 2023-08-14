using Core.Application.Responses;

namespace Application.Features.BookingProductRentalSlots.Commands.Create;

public class CreatedBookingProductRentalSlotResponse : IResponse
{
    public uint Id { get; set; }
    public string RentingType { get; set; }
    public decimal? DailyPrice { get; set; }
    public decimal? HourlyPrice { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }
}