using Application.Features.CartItems.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartItems.Rules;

public class CartItemBusinessRules : BaseBusinessRules
{
    private readonly ICartItemRepository _cartItemRepository;

    public CartItemBusinessRules(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public Task CartItemShouldExistWhenSelected(CartItem? cartItem)
    {
        if (cartItem == null)
            throw new BusinessException(CartItemsBusinessMessages.CartItemNotExists);
        return Task.CompletedTask;
    }

    public async Task CartItemIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartItem? cartItem = await _cartItemRepository.GetAsync(
            predicate: ci => ci.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartItemShouldExistWhenSelected(cartItem);
    }
}