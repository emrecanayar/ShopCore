using FluentValidation;

namespace Application.Features.CatalogRules.Commands.Delete;

public class DeleteCatalogRuleCommandValidator : AbstractValidator<DeleteCatalogRuleCommand>
{
    public DeleteCatalogRuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}