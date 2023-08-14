using FluentValidation;

namespace Application.Features.BookingProductTableSlots.Commands.Update;

public class UpdateBookingProductTableSlotCommandValidator : AbstractValidator<UpdateBookingProductTableSlotCommand>
{
    public UpdateBookingProductTableSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PriceType).NotEmpty();
        RuleFor(c => c.GuestLimit).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.BreakTime).NotEmpty();
        RuleFor(c => c.PreventSchedulingBefore).NotEmpty();
        RuleFor(c => c.SameSlotAllDays).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}