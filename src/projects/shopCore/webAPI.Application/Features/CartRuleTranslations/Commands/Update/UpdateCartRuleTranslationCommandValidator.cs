using FluentValidation;

namespace Application.Features.CartRuleTranslations.Commands.Update;

public class UpdateCartRuleTranslationCommandValidator : AbstractValidator<UpdateCartRuleTranslationCommand>
{
    public UpdateCartRuleTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.Label).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
    }
}