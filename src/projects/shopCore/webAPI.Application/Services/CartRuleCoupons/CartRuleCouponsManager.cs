using Application.Features.CartRuleCoupons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCoupons;

public class CartRuleCouponsManager : ICartRuleCouponsService
{
    private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
    private readonly CartRuleCouponBusinessRules _cartRuleCouponBusinessRules;

    public CartRuleCouponsManager(ICartRuleCouponRepository cartRuleCouponRepository, CartRuleCouponBusinessRules cartRuleCouponBusinessRules)
    {
        _cartRuleCouponRepository = cartRuleCouponRepository;
        _cartRuleCouponBusinessRules = cartRuleCouponBusinessRules;
    }

    public async Task<CartRuleCoupon?> GetAsync(
        Expression<Func<CartRuleCoupon, bool>> predicate,
        Func<IQueryable<CartRuleCoupon>, IIncludableQueryable<CartRuleCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleCoupon? cartRuleCoupon = await _cartRuleCouponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleCoupon;
    }

    public async Task<IPaginate<CartRuleCoupon>?> GetListAsync(
        Expression<Func<CartRuleCoupon, bool>>? predicate = null,
        Func<IQueryable<CartRuleCoupon>, IOrderedQueryable<CartRuleCoupon>>? orderBy = null,
        Func<IQueryable<CartRuleCoupon>, IIncludableQueryable<CartRuleCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleCoupon> cartRuleCouponList = await _cartRuleCouponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleCouponList;
    }

    public async Task<CartRuleCoupon> AddAsync(CartRuleCoupon cartRuleCoupon)
    {
        CartRuleCoupon addedCartRuleCoupon = await _cartRuleCouponRepository.AddAsync(cartRuleCoupon);

        return addedCartRuleCoupon;
    }

    public async Task<CartRuleCoupon> UpdateAsync(CartRuleCoupon cartRuleCoupon)
    {
        CartRuleCoupon updatedCartRuleCoupon = await _cartRuleCouponRepository.UpdateAsync(cartRuleCoupon);

        return updatedCartRuleCoupon;
    }

    public async Task<CartRuleCoupon> DeleteAsync(CartRuleCoupon cartRuleCoupon, bool permanent = false)
    {
        CartRuleCoupon deletedCartRuleCoupon = await _cartRuleCouponRepository.DeleteAsync(cartRuleCoupon);

        return deletedCartRuleCoupon;
    }
}
