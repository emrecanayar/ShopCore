using FluentValidation;

namespace Application.Features.CartItemInventories.Commands.Delete;

public class DeleteCartItemInventoryCommandValidator : AbstractValidator<DeleteCartItemInventoryCommand>
{
    public DeleteCartItemInventoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}