using FluentValidation;

namespace Application.Features.CartItemInventories.Commands.Update;

public class UpdateCartItemInventoryCommandValidator : AbstractValidator<UpdateCartItemInventoryCommand>
{
    public UpdateCartItemInventoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.InventorySourceId).NotEmpty();
        RuleFor(c => c.CartItemId).NotEmpty();
    }
}