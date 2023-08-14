using Application.Features.CartItemInventories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartItemInventories.Rules;

public class CartItemInventoryBusinessRules : BaseBusinessRules
{
    private readonly ICartItemInventoryRepository _cartItemInventoryRepository;

    public CartItemInventoryBusinessRules(ICartItemInventoryRepository cartItemInventoryRepository)
    {
        _cartItemInventoryRepository = cartItemInventoryRepository;
    }

    public Task CartItemInventoryShouldExistWhenSelected(CartItemInventory? cartItemInventory)
    {
        if (cartItemInventory == null)
            throw new BusinessException(CartItemInventoriesBusinessMessages.CartItemInventoryNotExists);
        return Task.CompletedTask;
    }

    public async Task CartItemInventoryIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartItemInventory? cartItemInventory = await _cartItemInventoryRepository.GetAsync(
            predicate: cii => cii.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartItemInventoryShouldExistWhenSelected(cartItemInventory);
    }
}