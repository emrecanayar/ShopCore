using FluentValidation;

namespace Application.Features.CartRuleCustomerGroups.Commands.Update;

public class UpdateCartRuleCustomerGroupCommandValidator : AbstractValidator<UpdateCartRuleCustomerGroupCommand>
{
    public UpdateCartRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.CustomerGroupId).NotEmpty();
    }
}