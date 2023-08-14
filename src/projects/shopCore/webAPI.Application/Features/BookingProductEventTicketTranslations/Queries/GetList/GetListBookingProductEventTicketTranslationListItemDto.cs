using Core.Application.Dtos;

namespace Application.Features.BookingProductEventTicketTranslations.Queries.GetList;

public class GetListBookingProductEventTicketTranslationListItemDto : IDto
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}