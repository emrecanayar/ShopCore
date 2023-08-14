using FluentValidation;

namespace Application.Features.CartRuleCouponUsages.Commands.Create;

public class CreateCartRuleCouponUsageCommandValidator : AbstractValidator<CreateCartRuleCouponUsageCommand>
{
    public CreateCartRuleCouponUsageCommandValidator()
    {
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.CartRuleCouponId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}