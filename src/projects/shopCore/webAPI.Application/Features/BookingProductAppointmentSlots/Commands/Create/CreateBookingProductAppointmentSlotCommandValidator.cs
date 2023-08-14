using FluentValidation;

namespace Application.Features.BookingProductAppointmentSlots.Commands.Create;

public class CreateBookingProductAppointmentSlotCommandValidator : AbstractValidator<CreateBookingProductAppointmentSlotCommand>
{
    public CreateBookingProductAppointmentSlotCommandValidator()
    {
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.BreakTime).NotEmpty();
        RuleFor(c => c.SameSlotAllDays).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}