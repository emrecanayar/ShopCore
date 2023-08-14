using Core.Application.Responses;

namespace Application.Features.BookingProductEventTickets.Queries.GetById;

public class GetByIdBookingProductEventTicketResponse : IResponse
{
    public uint Id { get; set; }
    public decimal? Price { get; set; }
    public int? Qty { get; set; }
    public decimal? SpecialPrice { get; set; }
    public DateTime? SpecialPriceFrom { get; set; }
    public DateTime? SpecialPriceTo { get; set; }
    public uint BookingProductId { get; set; }
}