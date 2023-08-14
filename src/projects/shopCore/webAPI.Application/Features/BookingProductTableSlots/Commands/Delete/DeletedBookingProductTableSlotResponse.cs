using Core.Application.Responses;

namespace Application.Features.BookingProductTableSlots.Commands.Delete;

public class DeletedBookingProductTableSlotResponse : IResponse
{
    public uint Id { get; set; }
}