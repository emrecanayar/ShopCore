using FluentValidation;

namespace Application.Features.CatalogRuleProducts.Commands.Create;

public class CreateCatalogRuleProductCommandValidator : AbstractValidator<CreateCatalogRuleProductCommand>
{
    public CreateCatalogRuleProductCommandValidator()
    {
        RuleFor(c => c.StartsFrom).NotEmpty();
        RuleFor(c => c.EndsTill).NotEmpty();
        RuleFor(c => c.EndOtherRules).NotEmpty();
        RuleFor(c => c.ActionType).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}