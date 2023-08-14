using FluentValidation;

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Create;

public class CreateBookingProductEventTicketTranslationCommandValidator : AbstractValidator<CreateBookingProductEventTicketTranslationCommand>
{
    public CreateBookingProductEventTicketTranslationCommandValidator()
    {
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}