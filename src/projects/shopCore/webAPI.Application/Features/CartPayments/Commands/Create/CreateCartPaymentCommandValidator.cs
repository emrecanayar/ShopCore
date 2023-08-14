using FluentValidation;

namespace Application.Features.CartPayments.Commands.Create;

public class CreateCartPaymentCommandValidator : AbstractValidator<CreateCartPaymentCommand>
{
    public CreateCartPaymentCommandValidator()
    {
        RuleFor(c => c.Method).NotEmpty();
        RuleFor(c => c.MethodTitle).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
    }
}