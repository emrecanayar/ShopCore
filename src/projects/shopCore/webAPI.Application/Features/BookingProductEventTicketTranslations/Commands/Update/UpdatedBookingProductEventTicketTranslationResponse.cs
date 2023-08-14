using Core.Application.Responses;

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Update;

public class UpdatedBookingProductEventTicketTranslationResponse : IResponse
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}