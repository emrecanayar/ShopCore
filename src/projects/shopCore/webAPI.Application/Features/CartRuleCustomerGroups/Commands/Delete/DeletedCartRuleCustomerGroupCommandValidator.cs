using FluentValidation;

namespace Application.Features.CartRuleCustomerGroups.Commands.Delete;

public class DeleteCartRuleCustomerGroupCommandValidator : AbstractValidator<DeleteCartRuleCustomerGroupCommand>
{
    public DeleteCartRuleCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}