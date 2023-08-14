using FluentValidation;

namespace Application.Features.CartRuleTranslations.Commands.Create;

public class CreateCartRuleTranslationCommandValidator : AbstractValidator<CreateCartRuleTranslationCommand>
{
    public CreateCartRuleTranslationCommandValidator()
    {
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Label).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
    }
}