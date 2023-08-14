using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCustomers;

public interface ICartRuleCustomersService
{
    Task<CartRuleCustomer?> GetAsync(
        Expression<Func<CartRuleCustomer, bool>> predicate,
        Func<IQueryable<CartRuleCustomer>, IIncludableQueryable<CartRuleCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleCustomer>?> GetListAsync(
        Expression<Func<CartRuleCustomer, bool>>? predicate = null,
        Func<IQueryable<CartRuleCustomer>, IOrderedQueryable<CartRuleCustomer>>? orderBy = null,
        Func<IQueryable<CartRuleCustomer>, IIncludableQueryable<CartRuleCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleCustomer> AddAsync(CartRuleCustomer cartRuleCustomer);
    Task<CartRuleCustomer> UpdateAsync(CartRuleCustomer cartRuleCustomer);
    Task<CartRuleCustomer> DeleteAsync(CartRuleCustomer cartRuleCustomer, bool permanent = false);
}
