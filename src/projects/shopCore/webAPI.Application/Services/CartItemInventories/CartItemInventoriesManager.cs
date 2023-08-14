using Application.Features.CartItemInventories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartItemInventories;

public class CartItemInventoriesManager : ICartItemInventoriesService
{
    private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
    private readonly CartItemInventoryBusinessRules _cartItemInventoryBusinessRules;

    public CartItemInventoriesManager(ICartItemInventoryRepository cartItemInventoryRepository, CartItemInventoryBusinessRules cartItemInventoryBusinessRules)
    {
        _cartItemInventoryRepository = cartItemInventoryRepository;
        _cartItemInventoryBusinessRules = cartItemInventoryBusinessRules;
    }

    public async Task<CartItemInventory?> GetAsync(
        Expression<Func<CartItemInventory, bool>> predicate,
        Func<IQueryable<CartItemInventory>, IIncludableQueryable<CartItemInventory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartItemInventory? cartItemInventory = await _cartItemInventoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartItemInventory;
    }

    public async Task<IPaginate<CartItemInventory>?> GetListAsync(
        Expression<Func<CartItemInventory, bool>>? predicate = null,
        Func<IQueryable<CartItemInventory>, IOrderedQueryable<CartItemInventory>>? orderBy = null,
        Func<IQueryable<CartItemInventory>, IIncludableQueryable<CartItemInventory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartItemInventory> cartItemInventoryList = await _cartItemInventoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartItemInventoryList;
    }

    public async Task<CartItemInventory> AddAsync(CartItemInventory cartItemInventory)
    {
        CartItemInventory addedCartItemInventory = await _cartItemInventoryRepository.AddAsync(cartItemInventory);

        return addedCartItemInventory;
    }

    public async Task<CartItemInventory> UpdateAsync(CartItemInventory cartItemInventory)
    {
        CartItemInventory updatedCartItemInventory = await _cartItemInventoryRepository.UpdateAsync(cartItemInventory);

        return updatedCartItemInventory;
    }

    public async Task<CartItemInventory> DeleteAsync(CartItemInventory cartItemInventory, bool permanent = false)
    {
        CartItemInventory deletedCartItemInventory = await _cartItemInventoryRepository.DeleteAsync(cartItemInventory);

        return deletedCartItemInventory;
    }
}
