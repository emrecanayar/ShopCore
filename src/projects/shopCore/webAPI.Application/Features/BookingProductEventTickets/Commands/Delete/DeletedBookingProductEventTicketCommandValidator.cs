using FluentValidation;

namespace Application.Features.BookingProductEventTickets.Commands.Delete;

public class DeleteBookingProductEventTicketCommandValidator : AbstractValidator<DeleteBookingProductEventTicketCommand>
{
    public DeleteBookingProductEventTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}