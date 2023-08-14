using Core.Application.Responses;

namespace Application.Features.Bookings.Commands.Delete;

public class DeletedBookingResponse : IResponse
{
    public uint Id { get; set; }
}