using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCoupons;

public interface ICartRuleCouponsService
{
    Task<CartRuleCoupon?> GetAsync(
        Expression<Func<CartRuleCoupon, bool>> predicate,
        Func<IQueryable<CartRuleCoupon>, IIncludableQueryable<CartRuleCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleCoupon>?> GetListAsync(
        Expression<Func<CartRuleCoupon, bool>>? predicate = null,
        Func<IQueryable<CartRuleCoupon>, IOrderedQueryable<CartRuleCoupon>>? orderBy = null,
        Func<IQueryable<CartRuleCoupon>, IIncludableQueryable<CartRuleCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleCoupon> AddAsync(CartRuleCoupon cartRuleCoupon);
    Task<CartRuleCoupon> UpdateAsync(CartRuleCoupon cartRuleCoupon);
    Task<CartRuleCoupon> DeleteAsync(CartRuleCoupon cartRuleCoupon, bool permanent = false);
}
