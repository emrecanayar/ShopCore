using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleTranslations;

public interface ICartRuleTranslationsService
{
    Task<CartRuleTranslation?> GetAsync(
        Expression<Func<CartRuleTranslation, bool>> predicate,
        Func<IQueryable<CartRuleTranslation>, IIncludableQueryable<CartRuleTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartRuleTranslation>?> GetListAsync(
        Expression<Func<CartRuleTranslation, bool>>? predicate = null,
        Func<IQueryable<CartRuleTranslation>, IOrderedQueryable<CartRuleTranslation>>? orderBy = null,
        Func<IQueryable<CartRuleTranslation>, IIncludableQueryable<CartRuleTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartRuleTranslation> AddAsync(CartRuleTranslation cartRuleTranslation);
    Task<CartRuleTranslation> UpdateAsync(CartRuleTranslation cartRuleTranslation);
    Task<CartRuleTranslation> DeleteAsync(CartRuleTranslation cartRuleTranslation, bool permanent = false);
}
