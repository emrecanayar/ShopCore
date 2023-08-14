using Core.Application.Responses;

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Delete;

public class DeletedBookingProductEventTicketTranslationResponse : IResponse
{
    public uint Id { get; set; }
}