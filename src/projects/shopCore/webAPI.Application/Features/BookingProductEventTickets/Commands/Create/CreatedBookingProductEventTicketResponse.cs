using Core.Application.Responses;

namespace Application.Features.BookingProductEventTickets.Commands.Create;

public class CreatedBookingProductEventTicketResponse : IResponse
{
    public uint Id { get; set; }
    public decimal? Price { get; set; }
    public int? Qty { get; set; }
    public decimal? SpecialPrice { get; set; }
    public DateTime? SpecialPriceFrom { get; set; }
    public DateTime? SpecialPriceTo { get; set; }
    public uint BookingProductId { get; set; }
}