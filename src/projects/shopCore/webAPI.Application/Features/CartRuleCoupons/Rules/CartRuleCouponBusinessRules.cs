using Application.Features.CartRuleCoupons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleCoupons.Rules;

public class CartRuleCouponBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleCouponRepository _cartRuleCouponRepository;

    public CartRuleCouponBusinessRules(ICartRuleCouponRepository cartRuleCouponRepository)
    {
        _cartRuleCouponRepository = cartRuleCouponRepository;
    }

    public Task CartRuleCouponShouldExistWhenSelected(CartRuleCoupon? cartRuleCoupon)
    {
        if (cartRuleCoupon == null)
            throw new BusinessException(CartRuleCouponsBusinessMessages.CartRuleCouponNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleCouponIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleCoupon? cartRuleCoupon = await _cartRuleCouponRepository.GetAsync(
            predicate: crc => crc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleCouponShouldExistWhenSelected(cartRuleCoupon);
    }
}