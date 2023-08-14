using Application.Features.CartShippingRates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartShippingRates.Rules;

public class CartShippingRateBusinessRules : BaseBusinessRules
{
    private readonly ICartShippingRateRepository _cartShippingRateRepository;

    public CartShippingRateBusinessRules(ICartShippingRateRepository cartShippingRateRepository)
    {
        _cartShippingRateRepository = cartShippingRateRepository;
    }

    public Task CartShippingRateShouldExistWhenSelected(CartShippingRate? cartShippingRate)
    {
        if (cartShippingRate == null)
            throw new BusinessException(CartShippingRatesBusinessMessages.CartShippingRateNotExists);
        return Task.CompletedTask;
    }

    public async Task CartShippingRateIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartShippingRate? cartShippingRate = await _cartShippingRateRepository.GetAsync(
            predicate: csr => csr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartShippingRateShouldExistWhenSelected(cartShippingRate);
    }
}