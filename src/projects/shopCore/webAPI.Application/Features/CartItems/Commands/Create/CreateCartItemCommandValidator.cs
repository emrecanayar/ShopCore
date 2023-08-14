using FluentValidation;

namespace Application.Features.CartItems.Commands.Create;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.Sku).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CouponCode).NotEmpty();
        RuleFor(c => c.Weight).NotEmpty();
        RuleFor(c => c.TotalWeight).NotEmpty();
        RuleFor(c => c.BaseTotalWeight).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.BasePrice).NotEmpty();
        RuleFor(c => c.Total).NotEmpty();
        RuleFor(c => c.BaseTotal).NotEmpty();
        RuleFor(c => c.TaxPercent).NotEmpty();
        RuleFor(c => c.TaxAmount).NotEmpty();
        RuleFor(c => c.BaseTaxAmount).NotEmpty();
        RuleFor(c => c.DiscountPercent).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.BaseDiscountAmount).NotEmpty();
        RuleFor(c => c.Additional).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
        RuleFor(c => c.TaxCategoryId).NotEmpty();
        RuleFor(c => c.CustomPrice).NotEmpty();
        RuleFor(c => c.AppliedCartRuleIds).NotEmpty();
    }
}