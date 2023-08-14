using FluentValidation;

namespace Application.Features.CartRuleCoupons.Commands.Delete;

public class DeleteCartRuleCouponCommandValidator : AbstractValidator<DeleteCartRuleCouponCommand>
{
    public DeleteCartRuleCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}