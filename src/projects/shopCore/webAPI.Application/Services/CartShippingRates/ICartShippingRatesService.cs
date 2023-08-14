using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartShippingRates;

public interface ICartShippingRatesService
{
    Task<CartShippingRate?> GetAsync(
        Expression<Func<CartShippingRate, bool>> predicate,
        Func<IQueryable<CartShippingRate>, IIncludableQueryable<CartShippingRate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartShippingRate>?> GetListAsync(
        Expression<Func<CartShippingRate, bool>>? predicate = null,
        Func<IQueryable<CartShippingRate>, IOrderedQueryable<CartShippingRate>>? orderBy = null,
        Func<IQueryable<CartShippingRate>, IIncludableQueryable<CartShippingRate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartShippingRate> AddAsync(CartShippingRate cartShippingRate);
    Task<CartShippingRate> UpdateAsync(CartShippingRate cartShippingRate);
    Task<CartShippingRate> DeleteAsync(CartShippingRate cartShippingRate, bool permanent = false);
}
