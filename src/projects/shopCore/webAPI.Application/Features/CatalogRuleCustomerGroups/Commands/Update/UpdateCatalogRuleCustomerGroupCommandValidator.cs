using FluentValidation;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Update;

public class UpdateCatalogRuleCustomerGroupCommandValidator : AbstractValidator<UpdateCatalogRuleCustomerGroupCommand>
{
    public UpdateCatalogRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
    }
}