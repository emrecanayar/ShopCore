using FluentValidation;

namespace Application.Features.CartRuleCoupons.Commands.Create;

public class CreateCartRuleCouponCommandValidator : AbstractValidator<CreateCartRuleCouponCommand>
{
    public CreateCartRuleCouponCommandValidator()
    {
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.UsageLimit).NotEmpty();
        RuleFor(c => c.UsagePerCustomer).NotEmpty();
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.IsPrimary).NotEmpty();
        RuleFor(c => c.ExpiredAt).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
    }
}