using FluentValidation;

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Update;

public class UpdateBookingProductEventTicketTranslationCommandValidator : AbstractValidator<UpdateBookingProductEventTicketTranslationCommand>
{
    public UpdateBookingProductEventTicketTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}