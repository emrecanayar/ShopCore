using Core.Application.Responses;

namespace Application.Features.BookingProductRentalSlots.Commands.Delete;

public class DeletedBookingProductRentalSlotResponse : IResponse
{
    public uint Id { get; set; }
}