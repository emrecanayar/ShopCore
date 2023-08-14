using FluentValidation;

namespace Application.Features.BookingProductDefaultSlots.Commands.Update;

public class UpdateBookingProductDefaultSlotCommandValidator : AbstractValidator<UpdateBookingProductDefaultSlotCommand>
{
    public UpdateBookingProductDefaultSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BookingType).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.BreakTime).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}