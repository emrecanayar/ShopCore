using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRules;

public interface ICartRulesService
{
    Task<CartRule?> GetAsync(
        Expression<Func<CartRule, bool>> predicate,
        Func<IQueryable<CartRule>, IIncludableQueryable<CartRule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRule>?> GetListAsync(
        Expression<Func<CartRule, bool>>? predicate = null,
        Func<IQueryable<CartRule>, IOrderedQueryable<CartRule>>? orderBy = null,
        Func<IQueryable<CartRule>, IIncludableQueryable<CartRule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRule> AddAsync(CartRule cartRule);
    Task<CartRule> UpdateAsync(CartRule cartRule);
    Task<CartRule> DeleteAsync(CartRule cartRule, bool permanent = false);
}
