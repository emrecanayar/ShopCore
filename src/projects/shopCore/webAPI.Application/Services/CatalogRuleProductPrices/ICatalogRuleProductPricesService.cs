using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleProductPrices;

public interface ICatalogRuleProductPricesService
{
    Task<CatalogRuleProductPrice?> GetAsync(
        Expression<Func<CatalogRuleProductPrice, bool>> predicate,
        Func<IQueryable<CatalogRuleProductPrice>, IIncludableQueryable<CatalogRuleProductPrice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogRuleProductPrice>?> GetListAsync(
        Expression<Func<CatalogRuleProductPrice, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleProductPrice>, IOrderedQueryable<CatalogRuleProductPrice>>? orderBy = null,
        Func<IQueryable<CatalogRuleProductPrice>, IIncludableQueryable<CatalogRuleProductPrice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogRuleProductPrice> AddAsync(CatalogRuleProductPrice catalogRuleProductPrice);
    Task<CatalogRuleProductPrice> UpdateAsync(CatalogRuleProductPrice catalogRuleProductPrice);
    Task<CatalogRuleProductPrice> DeleteAsync(CatalogRuleProductPrice catalogRuleProductPrice, bool permanent = false);
}
