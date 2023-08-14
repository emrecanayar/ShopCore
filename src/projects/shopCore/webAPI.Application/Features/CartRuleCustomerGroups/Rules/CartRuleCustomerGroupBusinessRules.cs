using Application.Features.CartRuleCustomerGroups.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleCustomerGroups.Rules;

public class CartRuleCustomerGroupBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;

    public CartRuleCustomerGroupBusinessRules(ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository)
    {
        _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
    }

    public Task CartRuleCustomerGroupShouldExistWhenSelected(CartRuleCustomerGroup? cartRuleCustomerGroup)
    {
        if (cartRuleCustomerGroup == null)
            throw new BusinessException(CartRuleCustomerGroupsBusinessMessages.CartRuleCustomerGroupNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleCustomerGroupIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleCustomerGroup? cartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.GetAsync(
            predicate: crcg => crcg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleCustomerGroupShouldExistWhenSelected(cartRuleCustomerGroup);
    }
}