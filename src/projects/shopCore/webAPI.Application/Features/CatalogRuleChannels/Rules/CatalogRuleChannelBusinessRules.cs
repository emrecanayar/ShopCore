using Application.Features.CatalogRuleChannels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CatalogRuleChannels.Rules;

public class CatalogRuleChannelBusinessRules : BaseBusinessRules
{
    private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;

    public CatalogRuleChannelBusinessRules(ICatalogRuleChannelRepository catalogRuleChannelRepository)
    {
        _catalogRuleChannelRepository = catalogRuleChannelRepository;
    }

    public Task CatalogRuleChannelShouldExistWhenSelected(CatalogRuleChannel? catalogRuleChannel)
    {
        if (catalogRuleChannel == null)
            throw new BusinessException(CatalogRuleChannelsBusinessMessages.CatalogRuleChannelNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogRuleChannelIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CatalogRuleChannel? catalogRuleChannel = await _catalogRuleChannelRepository.GetAsync(
            predicate: crc => crc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogRuleChannelShouldExistWhenSelected(catalogRuleChannel);
    }
}