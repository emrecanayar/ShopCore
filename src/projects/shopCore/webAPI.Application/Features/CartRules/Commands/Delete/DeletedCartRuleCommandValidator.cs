using FluentValidation;

namespace Application.Features.CartRules.Commands.Delete;

public class DeleteCartRuleCommandValidator : AbstractValidator<DeleteCartRuleCommand>
{
    public DeleteCartRuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}