using FluentValidation;

namespace Application.Features.AttributeOptionTranslations.Commands.Update;

public class UpdateAttributeOptionTranslationCommandValidator : AbstractValidator<UpdateAttributeOptionTranslationCommand>
{
    public UpdateAttributeOptionTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Label).NotEmpty();
        RuleFor(c => c.AttributeOptionId).NotEmpty();
    }
}