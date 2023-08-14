using FluentValidation;

namespace Application.Features.CartItems.Commands.Delete;

public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}