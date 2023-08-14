using FluentValidation;

namespace Application.Features.BookingProductDefaultSlots.Commands.Create;

public class CreateBookingProductDefaultSlotCommandValidator : AbstractValidator<CreateBookingProductDefaultSlotCommand>
{
    public CreateBookingProductDefaultSlotCommandValidator()
    {
        RuleFor(c => c.BookingType).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.BreakTime).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}