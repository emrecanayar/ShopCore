using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleChannels;

public interface ICatalogRuleChannelsService
{
    Task<CatalogRuleChannel?> GetAsync(
        Expression<Func<CatalogRuleChannel, bool>> predicate,
        Func<IQueryable<CatalogRuleChannel>, IIncludableQueryable<CatalogRuleChannel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CatalogRuleChannel>?> GetListAsync(
        Expression<Func<CatalogRuleChannel, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleChannel>, IOrderedQueryable<CatalogRuleChannel>>? orderBy = null,
        Func<IQueryable<CatalogRuleChannel>, IIncludableQueryable<CatalogRuleChannel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CatalogRuleChannel> AddAsync(CatalogRuleChannel catalogRuleChannel);
    Task<CatalogRuleChannel> UpdateAsync(CatalogRuleChannel catalogRuleChannel);
    Task<CatalogRuleChannel> DeleteAsync(CatalogRuleChannel catalogRuleChannel, bool permanent = false);
}
