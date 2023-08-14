using FluentValidation;

namespace Application.Features.CatalogRuleProducts.Commands.Delete;

public class DeleteCatalogRuleProductCommandValidator : AbstractValidator<DeleteCatalogRuleProductCommand>
{
    public DeleteCatalogRuleProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}