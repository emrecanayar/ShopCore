using Application.Features.CartRuleChannels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleChannels;

public class CartRuleChannelsManager : ICartRuleChannelsService
{
    private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
    private readonly CartRuleChannelBusinessRules _cartRuleChannelBusinessRules;

    public CartRuleChannelsManager(ICartRuleChannelRepository cartRuleChannelRepository, CartRuleChannelBusinessRules cartRuleChannelBusinessRules)
    {
        _cartRuleChannelRepository = cartRuleChannelRepository;
        _cartRuleChannelBusinessRules = cartRuleChannelBusinessRules;
    }

    public async Task<CartRuleChannel?> GetAsync(
        Expression<Func<CartRuleChannel, bool>> predicate,
        Func<IQueryable<CartRuleChannel>, IIncludableQueryable<CartRuleChannel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleChannel? cartRuleChannel = await _cartRuleChannelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleChannel;
    }

    public async Task<IPaginate<CartRuleChannel>?> GetListAsync(
        Expression<Func<CartRuleChannel, bool>>? predicate = null,
        Func<IQueryable<CartRuleChannel>, IOrderedQueryable<CartRuleChannel>>? orderBy = null,
        Func<IQueryable<CartRuleChannel>, IIncludableQueryable<CartRuleChannel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleChannel> cartRuleChannelList = await _cartRuleChannelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleChannelList;
    }

    public async Task<CartRuleChannel> AddAsync(CartRuleChannel cartRuleChannel)
    {
        CartRuleChannel addedCartRuleChannel = await _cartRuleChannelRepository.AddAsync(cartRuleChannel);

        return addedCartRuleChannel;
    }

    public async Task<CartRuleChannel> UpdateAsync(CartRuleChannel cartRuleChannel)
    {
        CartRuleChannel updatedCartRuleChannel = await _cartRuleChannelRepository.UpdateAsync(cartRuleChannel);

        return updatedCartRuleChannel;
    }

    public async Task<CartRuleChannel> DeleteAsync(CartRuleChannel cartRuleChannel, bool permanent = false)
    {
        CartRuleChannel deletedCartRuleChannel = await _cartRuleChannelRepository.DeleteAsync(cartRuleChannel);

        return deletedCartRuleChannel;
    }
}
