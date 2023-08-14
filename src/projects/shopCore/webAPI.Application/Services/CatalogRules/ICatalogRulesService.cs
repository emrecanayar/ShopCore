using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRules;

public interface ICatalogRulesService
{
    Task<CatalogRule?> GetAsync(
        Expression<Func<CatalogRule, bool>> predicate,
        Func<IQueryable<CatalogRule>, IIncludableQueryable<CatalogRule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogRule>?> GetListAsync(
        Expression<Func<CatalogRule, bool>>? predicate = null,
        Func<IQueryable<CatalogRule>, IOrderedQueryable<CatalogRule>>? orderBy = null,
        Func<IQueryable<CatalogRule>, IIncludableQueryable<CatalogRule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogRule> AddAsync(CatalogRule catalogRule);
    Task<CatalogRule> UpdateAsync(CatalogRule catalogRule);
    Task<CatalogRule> DeleteAsync(CatalogRule catalogRule, bool permanent = false);
}
