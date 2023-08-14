using FluentValidation;

namespace Application.Features.BookingProductAppointmentSlots.Commands.Update;

public class UpdateBookingProductAppointmentSlotCommandValidator : AbstractValidator<UpdateBookingProductAppointmentSlotCommand>
{
    public UpdateBookingProductAppointmentSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.BreakTime).NotEmpty();
        RuleFor(c => c.SameSlotAllDays).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}