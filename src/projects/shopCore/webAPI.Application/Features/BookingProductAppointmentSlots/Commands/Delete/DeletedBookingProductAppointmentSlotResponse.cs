using Core.Application.Responses;

namespace Application.Features.BookingProductAppointmentSlots.Commands.Delete;

public class DeletedBookingProductAppointmentSlotResponse : IResponse
{
    public uint Id { get; set; }
}