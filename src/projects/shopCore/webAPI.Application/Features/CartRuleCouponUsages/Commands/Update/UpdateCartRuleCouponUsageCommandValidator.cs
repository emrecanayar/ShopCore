using FluentValidation;

namespace Application.Features.CartRuleCouponUsages.Commands.Update;

public class UpdateCartRuleCouponUsageCommandValidator : AbstractValidator<UpdateCartRuleCouponUsageCommand>
{
    public UpdateCartRuleCouponUsageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.CartRuleCouponId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}