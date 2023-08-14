using FluentValidation;

namespace Application.Features.CatalogRules.Commands.Create;

public class CreateCatalogRuleCommandValidator : AbstractValidator<CreateCatalogRuleCommand>
{
    public CreateCatalogRuleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartsFrom).NotEmpty();
        RuleFor(c => c.EndsTill).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.ConditionType).NotEmpty();
        RuleFor(c => c.Conditions).NotEmpty();
        RuleFor(c => c.EndOtherRules).NotEmpty();
        RuleFor(c => c.ActionType).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
    }
}