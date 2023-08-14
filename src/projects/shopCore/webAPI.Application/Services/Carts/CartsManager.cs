using Application.Features.Carts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Carts;

public class CartsManager : ICartsService
{
    private readonly ICartRepository _cartRepository;
    private readonly CartBusinessRules _cartBusinessRules;

    public CartsManager(ICartRepository cartRepository, CartBusinessRules cartBusinessRules)
    {
        _cartRepository = cartRepository;
        _cartBusinessRules = cartBusinessRules;
    }

    public async Task<Cart?> GetAsync(
        Expression<Func<Cart, bool>> predicate,
        Func<IQueryable<Cart>, IIncludableQueryable<Cart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Cart? cart = await _cartRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cart;
    }

    public async Task<IPaginate<Cart>?> GetListAsync(
        Expression<Func<Cart, bool>>? predicate = null,
        Func<IQueryable<Cart>, IOrderedQueryable<Cart>>? orderBy = null,
        Func<IQueryable<Cart>, IIncludableQueryable<Cart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Cart> cartList = await _cartRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartList;
    }

    public async Task<Cart> AddAsync(Cart cart)
    {
        Cart addedCart = await _cartRepository.AddAsync(cart);

        return addedCart;
    }

    public async Task<Cart> UpdateAsync(Cart cart)
    {
        Cart updatedCart = await _cartRepository.UpdateAsync(cart);

        return updatedCart;
    }

    public async Task<Cart> DeleteAsync(Cart cart, bool permanent = false)
    {
        Cart deletedCart = await _cartRepository.DeleteAsync(cart);

        return deletedCart;
    }
}
