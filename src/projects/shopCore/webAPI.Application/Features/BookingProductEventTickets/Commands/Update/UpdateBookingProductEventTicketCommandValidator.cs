using FluentValidation;

namespace Application.Features.BookingProductEventTickets.Commands.Update;

public class UpdateBookingProductEventTicketCommandValidator : AbstractValidator<UpdateBookingProductEventTicketCommand>
{
    public UpdateBookingProductEventTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.SpecialPrice).NotEmpty();
        RuleFor(c => c.SpecialPriceFrom).NotEmpty();
        RuleFor(c => c.SpecialPriceTo).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}