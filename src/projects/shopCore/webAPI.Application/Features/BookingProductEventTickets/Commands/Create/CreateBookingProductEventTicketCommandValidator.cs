using FluentValidation;

namespace Application.Features.BookingProductEventTickets.Commands.Create;

public class CreateBookingProductEventTicketCommandValidator : AbstractValidator<CreateBookingProductEventTicketCommand>
{
    public CreateBookingProductEventTicketCommandValidator()
    {
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.SpecialPrice).NotEmpty();
        RuleFor(c => c.SpecialPriceFrom).NotEmpty();
        RuleFor(c => c.SpecialPriceTo).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}