using Application.Features.CartShippingRates.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartShippingRates;

public class CartShippingRatesManager : ICartShippingRatesService
{
    private readonly ICartShippingRateRepository _cartShippingRateRepository;
    private readonly CartShippingRateBusinessRules _cartShippingRateBusinessRules;

    public CartShippingRatesManager(ICartShippingRateRepository cartShippingRateRepository, CartShippingRateBusinessRules cartShippingRateBusinessRules)
    {
        _cartShippingRateRepository = cartShippingRateRepository;
        _cartShippingRateBusinessRules = cartShippingRateBusinessRules;
    }

    public async Task<CartShippingRate?> GetAsync(
        Expression<Func<CartShippingRate, bool>> predicate,
        Func<IQueryable<CartShippingRate>, IIncludableQueryable<CartShippingRate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartShippingRate? cartShippingRate = await _cartShippingRateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartShippingRate;
    }

    public async Task<IPaginate<CartShippingRate>?> GetListAsync(
        Expression<Func<CartShippingRate, bool>>? predicate = null,
        Func<IQueryable<CartShippingRate>, IOrderedQueryable<CartShippingRate>>? orderBy = null,
        Func<IQueryable<CartShippingRate>, IIncludableQueryable<CartShippingRate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartShippingRate> cartShippingRateList = await _cartShippingRateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartShippingRateList;
    }

    public async Task<CartShippingRate> AddAsync(CartShippingRate cartShippingRate)
    {
        CartShippingRate addedCartShippingRate = await _cartShippingRateRepository.AddAsync(cartShippingRate);

        return addedCartShippingRate;
    }

    public async Task<CartShippingRate> UpdateAsync(CartShippingRate cartShippingRate)
    {
        CartShippingRate updatedCartShippingRate = await _cartShippingRateRepository.UpdateAsync(cartShippingRate);

        return updatedCartShippingRate;
    }

    public async Task<CartShippingRate> DeleteAsync(CartShippingRate cartShippingRate, bool permanent = false)
    {
        CartShippingRate deletedCartShippingRate = await _cartShippingRateRepository.DeleteAsync(cartShippingRate);

        return deletedCartShippingRate;
    }
}
