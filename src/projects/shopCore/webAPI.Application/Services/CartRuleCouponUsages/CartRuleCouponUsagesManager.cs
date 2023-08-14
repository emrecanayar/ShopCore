using Application.Features.CartRuleCouponUsages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCouponUsages;

public class CartRuleCouponUsagesManager : ICartRuleCouponUsagesService
{
    private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
    private readonly CartRuleCouponUsageBusinessRules _cartRuleCouponUsageBusinessRules;

    public CartRuleCouponUsagesManager(ICartRuleCouponUsageRepository cartRuleCouponUsageRepository, CartRuleCouponUsageBusinessRules cartRuleCouponUsageBusinessRules)
    {
        _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
        _cartRuleCouponUsageBusinessRules = cartRuleCouponUsageBusinessRules;
    }

    public async Task<CartRuleCouponUsage?> GetAsync(
        Expression<Func<CartRuleCouponUsage, bool>> predicate,
        Func<IQueryable<CartRuleCouponUsage>, IIncludableQueryable<CartRuleCouponUsage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleCouponUsage? cartRuleCouponUsage = await _cartRuleCouponUsageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleCouponUsage;
    }

    public async Task<IPaginate<CartRuleCouponUsage>?> GetListAsync(
        Expression<Func<CartRuleCouponUsage, bool>>? predicate = null,
        Func<IQueryable<CartRuleCouponUsage>, IOrderedQueryable<CartRuleCouponUsage>>? orderBy = null,
        Func<IQueryable<CartRuleCouponUsage>, IIncludableQueryable<CartRuleCouponUsage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleCouponUsage> cartRuleCouponUsageList = await _cartRuleCouponUsageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleCouponUsageList;
    }

    public async Task<CartRuleCouponUsage> AddAsync(CartRuleCouponUsage cartRuleCouponUsage)
    {
        CartRuleCouponUsage addedCartRuleCouponUsage = await _cartRuleCouponUsageRepository.AddAsync(cartRuleCouponUsage);

        return addedCartRuleCouponUsage;
    }

    public async Task<CartRuleCouponUsage> UpdateAsync(CartRuleCouponUsage cartRuleCouponUsage)
    {
        CartRuleCouponUsage updatedCartRuleCouponUsage = await _cartRuleCouponUsageRepository.UpdateAsync(cartRuleCouponUsage);

        return updatedCartRuleCouponUsage;
    }

    public async Task<CartRuleCouponUsage> DeleteAsync(CartRuleCouponUsage cartRuleCouponUsage, bool permanent = false)
    {
        CartRuleCouponUsage deletedCartRuleCouponUsage = await _cartRuleCouponUsageRepository.DeleteAsync(cartRuleCouponUsage);

        return deletedCartRuleCouponUsage;
    }
}
