using FluentValidation;

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.From).NotEmpty();
        RuleFor(c => c.To).NotEmpty();
        RuleFor(c => c.OrderItemId).NotEmpty();
        RuleFor(c => c.BookingProductEventTicketId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}