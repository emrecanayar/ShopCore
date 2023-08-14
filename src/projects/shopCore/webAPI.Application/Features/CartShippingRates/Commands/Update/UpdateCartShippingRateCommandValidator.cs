using FluentValidation;

namespace Application.Features.CartShippingRates.Commands.Update;

public class UpdateCartShippingRateCommandValidator : AbstractValidator<UpdateCartShippingRateCommand>
{
    public UpdateCartShippingRateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Carrier).NotEmpty();
        RuleFor(c => c.CarrierTitle).NotEmpty();
        RuleFor(c => c.Method).NotEmpty();
        RuleFor(c => c.MethodTitle).NotEmpty();
        RuleFor(c => c.MethodDescription).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.BasePrice).NotEmpty();
        RuleFor(c => c.CartAddressId).NotEmpty();
        RuleFor(c => c.DiscountAmount).NotEmpty();
        RuleFor(c => c.BaseDiscountAmount).NotEmpty();
        RuleFor(c => c.IsCalculateTax).NotEmpty();
    }
}