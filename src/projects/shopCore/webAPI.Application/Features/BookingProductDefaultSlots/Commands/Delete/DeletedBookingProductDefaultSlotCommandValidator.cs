using FluentValidation;

namespace Application.Features.BookingProductDefaultSlots.Commands.Delete;

public class DeleteBookingProductDefaultSlotCommandValidator : AbstractValidator<DeleteBookingProductDefaultSlotCommand>
{
    public DeleteBookingProductDefaultSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}