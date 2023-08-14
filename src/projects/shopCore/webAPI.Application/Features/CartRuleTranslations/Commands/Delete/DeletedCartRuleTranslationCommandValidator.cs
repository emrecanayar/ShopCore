using FluentValidation;

namespace Application.Features.CartRuleTranslations.Commands.Delete;

public class DeleteCartRuleTranslationCommandValidator : AbstractValidator<DeleteCartRuleTranslationCommand>
{
    public DeleteCartRuleTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}