using FluentValidation;

namespace Application.Features.BookingProductRentalSlots.Commands.Delete;

public class DeleteBookingProductRentalSlotCommandValidator : AbstractValidator<DeleteBookingProductRentalSlotCommand>
{
    public DeleteBookingProductRentalSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}