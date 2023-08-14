using FluentValidation;

namespace Application.Features.BookingProductTableSlots.Commands.Delete;

public class DeleteBookingProductTableSlotCommandValidator : AbstractValidator<DeleteBookingProductTableSlotCommand>
{
    public DeleteBookingProductTableSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}