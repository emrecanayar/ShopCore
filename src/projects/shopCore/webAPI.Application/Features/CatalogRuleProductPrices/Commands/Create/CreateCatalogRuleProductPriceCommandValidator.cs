using FluentValidation;

namespace Application.Features.CatalogRuleProductPrices.Commands.Create;

public class CreateCatalogRuleProductPriceCommandValidator : AbstractValidator<CreateCatalogRuleProductPriceCommand>
{
    public CreateCatalogRuleProductPriceCommandValidator()
    {
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.RuleDate).NotEmpty();
        RuleFor(c => c.StartsFrom).NotEmpty();
        RuleFor(c => c.EndsTill).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}