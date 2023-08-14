using FluentValidation;

namespace Application.Features.BookingProductAppointmentSlots.Commands.Delete;

public class DeleteBookingProductAppointmentSlotCommandValidator : AbstractValidator<DeleteBookingProductAppointmentSlotCommand>
{
    public DeleteBookingProductAppointmentSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}