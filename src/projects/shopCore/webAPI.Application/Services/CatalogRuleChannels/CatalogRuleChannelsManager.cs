using Application.Features.CatalogRuleChannels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleChannels;

public class CatalogRuleChannelsManager : ICatalogRuleChannelsService
{
    private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
    private readonly CatalogRuleChannelBusinessRules _catalogRuleChannelBusinessRules;

    public CatalogRuleChannelsManager(ICatalogRuleChannelRepository catalogRuleChannelRepository, CatalogRuleChannelBusinessRules catalogRuleChannelBusinessRules)
    {
        _catalogRuleChannelRepository = catalogRuleChannelRepository;
        _catalogRuleChannelBusinessRules = catalogRuleChannelBusinessRules;
    }

    public async Task<CatalogRuleChannel?> GetAsync(
        Expression<Func<CatalogRuleChannel, bool>> predicate,
        Func<IQueryable<CatalogRuleChannel>, IIncludableQueryable<CatalogRuleChannel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogRuleChannel? catalogRuleChannel = await _catalogRuleChannelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogRuleChannel;
    }

    public async Task<IPaginate<CatalogRuleChannel>?> GetListAsync(
        Expression<Func<CatalogRuleChannel, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleChannel>, IOrderedQueryable<CatalogRuleChannel>>? orderBy = null,
        Func<IQueryable<CatalogRuleChannel>, IIncludableQueryable<CatalogRuleChannel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogRuleChannel> catalogRuleChannelList = await _catalogRuleChannelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogRuleChannelList;
    }

    public async Task<CatalogRuleChannel> AddAsync(CatalogRuleChannel catalogRuleChannel)
    {
        CatalogRuleChannel addedCatalogRuleChannel = await _catalogRuleChannelRepository.AddAsync(catalogRuleChannel);

        return addedCatalogRuleChannel;
    }

    public async Task<CatalogRuleChannel> UpdateAsync(CatalogRuleChannel catalogRuleChannel)
    {
        CatalogRuleChannel updatedCatalogRuleChannel = await _catalogRuleChannelRepository.UpdateAsync(catalogRuleChannel);

        return updatedCatalogRuleChannel;
    }

    public async Task<CatalogRuleChannel> DeleteAsync(CatalogRuleChannel catalogRuleChannel, bool permanent = false)
    {
        CatalogRuleChannel deletedCatalogRuleChannel = await _catalogRuleChannelRepository.DeleteAsync(catalogRuleChannel);

        return deletedCatalogRuleChannel;
    }
}
