using FluentValidation;

namespace Application.Features.CartPayments.Commands.Update;

public class UpdateCartPaymentCommandValidator : AbstractValidator<UpdateCartPaymentCommand>
{
    public UpdateCartPaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Method).NotEmpty();
        RuleFor(c => c.MethodTitle).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
    }
}