using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartItemInventories;

public interface ICartItemInventoriesService
{
    Task<CartItemInventory?> GetAsync(
        Expression<Func<CartItemInventory, bool>> predicate,
        Func<IQueryable<CartItemInventory>, IIncludableQueryable<CartItemInventory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartItemInventory>?> GetListAsync(
        Expression<Func<CartItemInventory, bool>>? predicate = null,
        Func<IQueryable<CartItemInventory>, IOrderedQueryable<CartItemInventory>>? orderBy = null,
        Func<IQueryable<CartItemInventory>, IIncludableQueryable<CartItemInventory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartItemInventory> AddAsync(CartItemInventory cartItemInventory);
    Task<CartItemInventory> UpdateAsync(CartItemInventory cartItemInventory);
    Task<CartItemInventory> DeleteAsync(CartItemInventory cartItemInventory, bool permanent = false);
}
