using Application.Features.Carts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Carts.Rules;

public class CartBusinessRules : BaseBusinessRules
{
    private readonly ICartRepository _cartRepository;

    public CartBusinessRules(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task CartShouldExistWhenSelected(Cart? cart)
    {
        if (cart == null)
            throw new BusinessException(CartsBusinessMessages.CartNotExists);
        return Task.CompletedTask;
    }

    public async Task CartIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Cart? cart = await _cartRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartShouldExistWhenSelected(cart);
    }
}