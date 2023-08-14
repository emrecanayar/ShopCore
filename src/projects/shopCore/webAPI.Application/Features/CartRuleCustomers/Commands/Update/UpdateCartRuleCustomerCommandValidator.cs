using FluentValidation;

namespace Application.Features.CartRuleCustomers.Commands.Update;

public class UpdateCartRuleCustomerCommandValidator : AbstractValidator<UpdateCartRuleCustomerCommand>
{
    public UpdateCartRuleCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}