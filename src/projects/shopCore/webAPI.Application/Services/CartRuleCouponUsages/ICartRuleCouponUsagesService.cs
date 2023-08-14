using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCouponUsages;

public interface ICartRuleCouponUsagesService
{
    Task<CartRuleCouponUsage?> GetAsync(
        Expression<Func<CartRuleCouponUsage, bool>> predicate,
        Func<IQueryable<CartRuleCouponUsage>, IIncludableQueryable<CartRuleCouponUsage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleCouponUsage>?> GetListAsync(
        Expression<Func<CartRuleCouponUsage, bool>>? predicate = null,
        Func<IQueryable<CartRuleCouponUsage>, IOrderedQueryable<CartRuleCouponUsage>>? orderBy = null,
        Func<IQueryable<CartRuleCouponUsage>, IIncludableQueryable<CartRuleCouponUsage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleCouponUsage> AddAsync(CartRuleCouponUsage cartRuleCouponUsage);
    Task<CartRuleCouponUsage> UpdateAsync(CartRuleCouponUsage cartRuleCouponUsage);
    Task<CartRuleCouponUsage> DeleteAsync(CartRuleCouponUsage cartRuleCouponUsage, bool permanent = false);
}
