using Application.Features.CartRuleCustomerGroups.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCustomerGroups;

public class CartRuleCustomerGroupsManager : ICartRuleCustomerGroupsService
{
    private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
    private readonly CartRuleCustomerGroupBusinessRules _cartRuleCustomerGroupBusinessRules;

    public CartRuleCustomerGroupsManager(ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository, CartRuleCustomerGroupBusinessRules cartRuleCustomerGroupBusinessRules)
    {
        _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
        _cartRuleCustomerGroupBusinessRules = cartRuleCustomerGroupBusinessRules;
    }

    public async Task<CartRuleCustomerGroup?> GetAsync(
        Expression<Func<CartRuleCustomerGroup, bool>> predicate,
        Func<IQueryable<CartRuleCustomerGroup>, IIncludableQueryable<CartRuleCustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleCustomerGroup? cartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleCustomerGroup;
    }

    public async Task<IPaginate<CartRuleCustomerGroup>?> GetListAsync(
        Expression<Func<CartRuleCustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CartRuleCustomerGroup>, IOrderedQueryable<CartRuleCustomerGroup>>? orderBy = null,
        Func<IQueryable<CartRuleCustomerGroup>, IIncludableQueryable<CartRuleCustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleCustomerGroup> cartRuleCustomerGroupList = await _cartRuleCustomerGroupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleCustomerGroupList;
    }

    public async Task<CartRuleCustomerGroup> AddAsync(CartRuleCustomerGroup cartRuleCustomerGroup)
    {
        CartRuleCustomerGroup addedCartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.AddAsync(cartRuleCustomerGroup);

        return addedCartRuleCustomerGroup;
    }

    public async Task<CartRuleCustomerGroup> UpdateAsync(CartRuleCustomerGroup cartRuleCustomerGroup)
    {
        CartRuleCustomerGroup updatedCartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.UpdateAsync(cartRuleCustomerGroup);

        return updatedCartRuleCustomerGroup;
    }

    public async Task<CartRuleCustomerGroup> DeleteAsync(CartRuleCustomerGroup cartRuleCustomerGroup, bool permanent = false)
    {
        CartRuleCustomerGroup deletedCartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.DeleteAsync(cartRuleCustomerGroup);

        return deletedCartRuleCustomerGroup;
    }
}
