using Core.Application.Dtos;

namespace Application.Features.BookingProductEventTickets.Queries.GetList;

public class GetListBookingProductEventTicketListItemDto : IDto
{
    public uint Id { get; set; }
    public decimal? Price { get; set; }
    public int? Qty { get; set; }
    public decimal? SpecialPrice { get; set; }
    public DateTime? SpecialPriceFrom { get; set; }
    public DateTime? SpecialPriceTo { get; set; }
    public uint BookingProductId { get; set; }
}