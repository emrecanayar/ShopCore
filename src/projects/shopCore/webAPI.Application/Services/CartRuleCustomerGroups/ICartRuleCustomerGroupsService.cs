using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCustomerGroups;

public interface ICartRuleCustomerGroupsService
{
    Task<CartRuleCustomerGroup?> GetAsync(
        Expression<Func<CartRuleCustomerGroup, bool>> predicate,
        Func<IQueryable<CartRuleCustomerGroup>, IIncludableQueryable<CartRuleCustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleCustomerGroup>?> GetListAsync(
        Expression<Func<CartRuleCustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CartRuleCustomerGroup>, IOrderedQueryable<CartRuleCustomerGroup>>? orderBy = null,
        Func<IQueryable<CartRuleCustomerGroup>, IIncludableQueryable<CartRuleCustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleCustomerGroup> AddAsync(CartRuleCustomerGroup cartRuleCustomerGroup);
    Task<CartRuleCustomerGroup> UpdateAsync(CartRuleCustomerGroup cartRuleCustomerGroup);
    Task<CartRuleCustomerGroup> DeleteAsync(CartRuleCustomerGroup cartRuleCustomerGroup, bool permanent = false);
}
