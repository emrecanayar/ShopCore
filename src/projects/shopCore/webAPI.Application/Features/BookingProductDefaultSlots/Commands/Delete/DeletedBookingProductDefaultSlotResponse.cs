using Core.Application.Responses;

namespace Application.Features.BookingProductDefaultSlots.Commands.Delete;

public class DeletedBookingProductDefaultSlotResponse : IResponse
{
    public uint Id { get; set; }
}