using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Carts;

public interface ICartsService
{
    Task<Cart?> GetAsync(
        Expression<Func<Cart, bool>> predicate,
        Func<IQueryable<Cart>, IIncludableQueryable<Cart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Cart>?> GetListAsync(
        Expression<Func<Cart, bool>>? predicate = null,
        Func<IQueryable<Cart>, IOrderedQueryable<Cart>>? orderBy = null,
        Func<IQueryable<Cart>, IIncludableQueryable<Cart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Cart> AddAsync(Cart cart);
    Task<Cart> UpdateAsync(Cart cart);
    Task<Cart> DeleteAsync(Cart cart, bool permanent = false);
}
