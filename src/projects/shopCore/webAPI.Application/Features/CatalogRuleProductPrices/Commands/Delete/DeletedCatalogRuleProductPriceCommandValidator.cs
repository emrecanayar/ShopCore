using FluentValidation;

namespace Application.Features.CatalogRuleProductPrices.Commands.Delete;

public class DeleteCatalogRuleProductPriceCommandValidator : AbstractValidator<DeleteCatalogRuleProductPriceCommand>
{
    public DeleteCatalogRuleProductPriceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}