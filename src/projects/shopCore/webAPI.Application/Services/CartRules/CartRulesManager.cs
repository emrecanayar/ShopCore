using Application.Features.CartRules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRules;

public class CartRulesManager : ICartRulesService
{
    private readonly ICartRuleRepository _cartRuleRepository;
    private readonly CartRuleBusinessRules _cartRuleBusinessRules;

    public CartRulesManager(ICartRuleRepository cartRuleRepository, CartRuleBusinessRules cartRuleBusinessRules)
    {
        _cartRuleRepository = cartRuleRepository;
        _cartRuleBusinessRules = cartRuleBusinessRules;
    }

    public async Task<CartRule?> GetAsync(
        Expression<Func<CartRule, bool>> predicate,
        Func<IQueryable<CartRule>, IIncludableQueryable<CartRule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRule? cartRule = await _cartRuleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRule;
    }

    public async Task<IPaginate<CartRule>?> GetListAsync(
        Expression<Func<CartRule, bool>>? predicate = null,
        Func<IQueryable<CartRule>, IOrderedQueryable<CartRule>>? orderBy = null,
        Func<IQueryable<CartRule>, IIncludableQueryable<CartRule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRule> cartRuleList = await _cartRuleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleList;
    }

    public async Task<CartRule> AddAsync(CartRule cartRule)
    {
        CartRule addedCartRule = await _cartRuleRepository.AddAsync(cartRule);

        return addedCartRule;
    }

    public async Task<CartRule> UpdateAsync(CartRule cartRule)
    {
        CartRule updatedCartRule = await _cartRuleRepository.UpdateAsync(cartRule);

        return updatedCartRule;
    }

    public async Task<CartRule> DeleteAsync(CartRule cartRule, bool permanent = false)
    {
        CartRule deletedCartRule = await _cartRuleRepository.DeleteAsync(cartRule);

        return deletedCartRule;
    }
}
