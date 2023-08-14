using FluentValidation;

namespace Application.Features.CartShippingRates.Commands.Delete;

public class DeleteCartShippingRateCommandValidator : AbstractValidator<DeleteCartShippingRateCommand>
{
    public DeleteCartShippingRateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}