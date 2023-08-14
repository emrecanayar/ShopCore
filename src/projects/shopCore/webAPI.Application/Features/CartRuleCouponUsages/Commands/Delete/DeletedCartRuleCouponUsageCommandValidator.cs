using FluentValidation;

namespace Application.Features.CartRuleCouponUsages.Commands.Delete;

public class DeleteCartRuleCouponUsageCommandValidator : AbstractValidator<DeleteCartRuleCouponUsageCommand>
{
    public DeleteCartRuleCouponUsageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}