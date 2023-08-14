using Application.Features.CartRules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRules.Rules;

public class CartRuleBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleRepository _cartRuleRepository;

    public CartRuleBusinessRules(ICartRuleRepository cartRuleRepository)
    {
        _cartRuleRepository = cartRuleRepository;
    }

    public Task CartRuleShouldExistWhenSelected(CartRule? cartRule)
    {
        if (cartRule == null)
            throw new BusinessException(CartRulesBusinessMessages.CartRuleNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRule? cartRule = await _cartRuleRepository.GetAsync(
            predicate: cr => cr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleShouldExistWhenSelected(cartRule);
    }
}