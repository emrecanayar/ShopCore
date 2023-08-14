using FluentValidation;

namespace Application.Features.BookingProducts.Commands.Delete;

public class DeleteBookingProductCommandValidator : AbstractValidator<DeleteBookingProductCommand>
{
    public DeleteBookingProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}