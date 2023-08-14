using FluentValidation;

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Delete;

public class DeleteBookingProductEventTicketTranslationCommandValidator : AbstractValidator<DeleteBookingProductEventTicketTranslationCommand>
{
    public DeleteBookingProductEventTicketTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}