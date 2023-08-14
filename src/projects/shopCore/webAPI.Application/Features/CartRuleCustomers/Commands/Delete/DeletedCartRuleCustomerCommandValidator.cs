using FluentValidation;

namespace Application.Features.CartRuleCustomers.Commands.Delete;

public class DeleteCartRuleCustomerCommandValidator : AbstractValidator<DeleteCartRuleCustomerCommand>
{
    public DeleteCartRuleCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}