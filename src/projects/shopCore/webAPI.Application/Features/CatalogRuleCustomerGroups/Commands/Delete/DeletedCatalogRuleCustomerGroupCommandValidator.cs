using FluentValidation;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Delete;

public class DeleteCatalogRuleCustomerGroupCommandValidator : AbstractValidator<DeleteCatalogRuleCustomerGroupCommand>
{
    public DeleteCatalogRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}