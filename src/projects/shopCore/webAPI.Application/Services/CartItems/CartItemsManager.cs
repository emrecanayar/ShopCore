using Application.Features.CartItems.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartItems;

public class CartItemsManager : ICartItemsService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly CartItemBusinessRules _cartItemBusinessRules;

    public CartItemsManager(ICartItemRepository cartItemRepository, CartItemBusinessRules cartItemBusinessRules)
    {
        _cartItemRepository = cartItemRepository;
        _cartItemBusinessRules = cartItemBusinessRules;
    }

    public async Task<CartItem?> GetAsync(
        Expression<Func<CartItem, bool>> predicate,
        Func<IQueryable<CartItem>, IIncludableQueryable<CartItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartItem? cartItem = await _cartItemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartItem;
    }

    public async Task<IPaginate<CartItem>?> GetListAsync(
        Expression<Func<CartItem, bool>>? predicate = null,
        Func<IQueryable<CartItem>, IOrderedQueryable<CartItem>>? orderBy = null,
        Func<IQueryable<CartItem>, IIncludableQueryable<CartItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartItem> cartItemList = await _cartItemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartItemList;
    }

    public async Task<CartItem> AddAsync(CartItem cartItem)
    {
        CartItem addedCartItem = await _cartItemRepository.AddAsync(cartItem);

        return addedCartItem;
    }

    public async Task<CartItem> UpdateAsync(CartItem cartItem)
    {
        CartItem updatedCartItem = await _cartItemRepository.UpdateAsync(cartItem);

        return updatedCartItem;
    }

    public async Task<CartItem> DeleteAsync(CartItem cartItem, bool permanent = false)
    {
        CartItem deletedCartItem = await _cartItemRepository.DeleteAsync(cartItem);

        return deletedCartItem;
    }
}
