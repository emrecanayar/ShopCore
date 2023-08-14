using FluentValidation;

namespace Application.Features.AttributeOptionTranslations.Commands.Create;

public class CreateAttributeOptionTranslationCommandValidator : AbstractValidator<CreateAttributeOptionTranslationCommand>
{
    public CreateAttributeOptionTranslationCommandValidator()
    {
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Label).NotEmpty();
        RuleFor(c => c.AttributeOptionId).NotEmpty();
    }
}