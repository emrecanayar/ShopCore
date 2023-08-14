using Application.Features.CartRuleChannels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleChannels.Rules;

public class CartRuleChannelBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleChannelRepository _cartRuleChannelRepository;

    public CartRuleChannelBusinessRules(ICartRuleChannelRepository cartRuleChannelRepository)
    {
        _cartRuleChannelRepository = cartRuleChannelRepository;
    }

    public Task CartRuleChannelShouldExistWhenSelected(CartRuleChannel? cartRuleChannel)
    {
        if (cartRuleChannel == null)
            throw new BusinessException(CartRuleChannelsBusinessMessages.CartRuleChannelNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleChannelIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleChannel? cartRuleChannel = await _cartRuleChannelRepository.GetAsync(
            predicate: crc => crc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleChannelShouldExistWhenSelected(cartRuleChannel);
    }
}