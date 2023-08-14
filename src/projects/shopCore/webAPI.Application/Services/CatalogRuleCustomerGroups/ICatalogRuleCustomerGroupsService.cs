using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleCustomerGroups;

public interface ICatalogRuleCustomerGroupsService
{
    Task<CatalogRuleCustomerGroup?> GetAsync(
        Expression<Func<CatalogRuleCustomerGroup, bool>> predicate,
        Func<IQueryable<CatalogRuleCustomerGroup>, IIncludableQueryable<CatalogRuleCustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogRuleCustomerGroup>?> GetListAsync(
        Expression<Func<CatalogRuleCustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleCustomerGroup>, IOrderedQueryable<CatalogRuleCustomerGroup>>? orderBy = null,
        Func<IQueryable<CatalogRuleCustomerGroup>, IIncludableQueryable<CatalogRuleCustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogRuleCustomerGroup> AddAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup);
    Task<CatalogRuleCustomerGroup> UpdateAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup);
    Task<CatalogRuleCustomerGroup> DeleteAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup, bool permanent = false);
}
