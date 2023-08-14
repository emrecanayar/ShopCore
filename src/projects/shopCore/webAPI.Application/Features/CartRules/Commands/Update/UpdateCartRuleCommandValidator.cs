using FluentValidation;

namespace Application.Features.CartRules.Commands.Update;

public class UpdateCartRuleCommandValidator : AbstractValidator<UpdateCartRuleCommand>
{
    public UpdateCartRuleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartsFrom).NotEmpty();
        RuleFor(c => c.EndsTill).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.CouponType).NotEmpty();
        RuleFor(c => c.UseAutoGeneration).NotEmpty();
        RuleFor(c => c.UsagePerCustomer).NotEmpty();
        RuleFor(c => c.UsesPerCoupon).NotEmpty();
        RuleFor(c => c.TimesUsed).NotEmpty();
        RuleFor(c => c.ConditionType).NotEmpty();
        RuleFor(c => c.Conditions).NotEmpty();
        RuleFor(c => c.EndOtherRules).NotEmpty();
        RuleFor(c => c.UsesAttributeConditions).NotEmpty();
        RuleFor(c => c.ActionType).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.DiscountQuantity).NotEmpty();
        RuleFor(c => c.DiscountStep).NotEmpty();
        RuleFor(c => c.ApplyToShipping).NotEmpty();
        RuleFor(c => c.FreeShipping).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
    }
}