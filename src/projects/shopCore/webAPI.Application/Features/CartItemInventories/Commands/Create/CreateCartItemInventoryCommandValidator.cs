using FluentValidation;

namespace Application.Features.CartItemInventories.Commands.Create;

public class CreateCartItemInventoryCommandValidator : AbstractValidator<CreateCartItemInventoryCommand>
{
    public CreateCartItemInventoryCommandValidator()
    {
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.InventorySourceId).NotEmpty();
        RuleFor(c => c.CartItemId).NotEmpty();
    }
}