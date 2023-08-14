using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleProducts;

public interface ICatalogRuleProductsService
{
    Task<CatalogRuleProduct?> GetAsync(
        Expression<Func<CatalogRuleProduct, bool>> predicate,
        Func<IQueryable<CatalogRuleProduct>, IIncludableQueryable<CatalogRuleProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogRuleProduct>?> GetListAsync(
        Expression<Func<CatalogRuleProduct, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleProduct>, IOrderedQueryable<CatalogRuleProduct>>? orderBy = null,
        Func<IQueryable<CatalogRuleProduct>, IIncludableQueryable<CatalogRuleProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogRuleProduct> AddAsync(CatalogRuleProduct catalogRuleProduct);
    Task<CatalogRuleProduct> UpdateAsync(CatalogRuleProduct catalogRuleProduct);
    Task<CatalogRuleProduct> DeleteAsync(CatalogRuleProduct catalogRuleProduct, bool permanent = false);
}
