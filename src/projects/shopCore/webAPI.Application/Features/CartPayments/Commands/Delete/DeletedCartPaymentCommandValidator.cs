using FluentValidation;

namespace Application.Features.CartPayments.Commands.Delete;

public class DeleteCartPaymentCommandValidator : AbstractValidator<DeleteCartPaymentCommand>
{
    public DeleteCartPaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}