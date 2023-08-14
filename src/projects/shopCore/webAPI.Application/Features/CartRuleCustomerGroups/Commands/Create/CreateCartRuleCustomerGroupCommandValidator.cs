using FluentValidation;

namespace Application.Features.CartRuleCustomerGroups.Commands.Create;

public class CreateCartRuleCustomerGroupCommandValidator : AbstractValidator<CreateCartRuleCustomerGroupCommand>
{
    public CreateCartRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
    }
}