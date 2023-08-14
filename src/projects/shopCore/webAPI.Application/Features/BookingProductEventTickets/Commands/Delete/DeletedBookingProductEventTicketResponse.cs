using Core.Application.Responses;

namespace Application.Features.BookingProductEventTickets.Commands.Delete;

public class DeletedBookingProductEventTicketResponse : IResponse
{
    public uint Id { get; set; }
}