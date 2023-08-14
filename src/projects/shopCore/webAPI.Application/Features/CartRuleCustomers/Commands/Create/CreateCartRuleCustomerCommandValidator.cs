using FluentValidation;

namespace Application.Features.CartRuleCustomers.Commands.Create;

public class CreateCartRuleCustomerCommandValidator : AbstractValidator<CreateCartRuleCustomerCommand>
{
    public CreateCartRuleCustomerCommandValidator()
    {
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}