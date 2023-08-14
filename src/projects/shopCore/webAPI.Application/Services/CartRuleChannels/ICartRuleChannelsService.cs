using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleChannels;

public interface ICartRuleChannelsService
{
    Task<CartRuleChannel?> GetAsync(
        Expression<Func<CartRuleChannel, bool>> predicate,
        Func<IQueryable<CartRuleChannel>, IIncludableQueryable<CartRuleChannel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleChannel>?> GetListAsync(
        Expression<Func<CartRuleChannel, bool>>? predicate = null,
        Func<IQueryable<CartRuleChannel>, IOrderedQueryable<CartRuleChannel>>? orderBy = null,
        Func<IQueryable<CartRuleChannel>, IIncludableQueryable<CartRuleChannel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleChannel> AddAsync(CartRuleChannel cartRuleChannel);
    Task<CartRuleChannel> UpdateAsync(CartRuleChannel cartRuleChannel);
    Task<CartRuleChannel> DeleteAsync(CartRuleChannel cartRuleChannel, bool permanent = false);
}
