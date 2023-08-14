using FluentValidation;

namespace Application.Features.Carts.Commands.Update;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerEmail).NotEmpty();
        RuleFor(c => c.CustomerFirstName).NotEmpty();
        RuleFor(c => c.CustomerLastName).NotEmpty();
        RuleFor(c => c.ShippingMethod).NotEmpty();
        RuleFor(c => c.CouponCode).NotEmpty();
        RuleFor(c => c.IsGift).NotEmpty();
        RuleFor(c => c.ItemsCount).NotEmpty();
        RuleFor(c => c.ItemsQty).NotEmpty();
        RuleFor(c => c.ExchangeRate).NotEmpty();
        RuleFor(c => c.GlobalCurrencyCode).NotEmpty();
        RuleFor(c => c.BaseCurrencyCode).NotEmpty();
        RuleFor(c => c.ChannelCurrencyCode).NotEmpty();
        RuleFor(c => c.CartCurrencyCode).NotEmpty();
        RuleFor(c => c.GrandTotal).NotEmpty();
        RuleFor(c => c.BaseGrandTotal).NotEmpty();
        RuleFor(c => c.SubTotal).NotEmpty();
        RuleFor(c => c.BaseSubTotal).NotEmpty();
        RuleFor(c => c.TaxTotal).NotEmpty();
        RuleFor(c => c.BaseTaxTotal).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.BaseDiscountAmount).NotEmpty();
        RuleFor(c => c.CheckoutMethod).NotEmpty();
        RuleFor(c => c.IsGuest).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.ConversionTime).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
        RuleFor(c => c.AppliedCartRuleIds).NotEmpty();
    }
}