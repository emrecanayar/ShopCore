using FluentValidation;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Create;

public class CreateCatalogRuleCustomerGroupCommandValidator : AbstractValidator<CreateCatalogRuleCustomerGroupCommand>
{
    public CreateCatalogRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
    }
}