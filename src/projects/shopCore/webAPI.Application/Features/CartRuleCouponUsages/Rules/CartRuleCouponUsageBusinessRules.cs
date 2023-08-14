using Application.Features.CartRuleCouponUsages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleCouponUsages.Rules;

public class CartRuleCouponUsageBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;

    public CartRuleCouponUsageBusinessRules(ICartRuleCouponUsageRepository cartRuleCouponUsageRepository)
    {
        _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
    }

    public Task CartRuleCouponUsageShouldExistWhenSelected(CartRuleCouponUsage? cartRuleCouponUsage)
    {
        if (cartRuleCouponUsage == null)
            throw new BusinessException(CartRuleCouponUsagesBusinessMessages.CartRuleCouponUsageNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleCouponUsageIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleCouponUsage? cartRuleCouponUsage = await _cartRuleCouponUsageRepository.GetAsync(
            predicate: crcu => crcu.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleCouponUsageShouldExistWhenSelected(cartRuleCouponUsage);
    }
}