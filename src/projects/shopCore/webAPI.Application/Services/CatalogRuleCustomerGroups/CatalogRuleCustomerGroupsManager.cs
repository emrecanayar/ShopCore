using Application.Features.CatalogRuleCustomerGroups.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleCustomerGroups;

public class CatalogRuleCustomerGroupsManager : ICatalogRuleCustomerGroupsService
{
    private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
    private readonly CatalogRuleCustomerGroupBusinessRules _catalogRuleCustomerGroupBusinessRules;

    public CatalogRuleCustomerGroupsManager(ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository, CatalogRuleCustomerGroupBusinessRules catalogRuleCustomerGroupBusinessRules)
    {
        _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
        _catalogRuleCustomerGroupBusinessRules = catalogRuleCustomerGroupBusinessRules;
    }

    public async Task<CatalogRuleCustomerGroup?> GetAsync(
        Expression<Func<CatalogRuleCustomerGroup, bool>> predicate,
        Func<IQueryable<CatalogRuleCustomerGroup>, IIncludableQueryable<CatalogRuleCustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogRuleCustomerGroup? catalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogRuleCustomerGroup;
    }

    public async Task<IPaginate<CatalogRuleCustomerGroup>?> GetListAsync(
        Expression<Func<CatalogRuleCustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleCustomerGroup>, IOrderedQueryable<CatalogRuleCustomerGroup>>? orderBy = null,
        Func<IQueryable<CatalogRuleCustomerGroup>, IIncludableQueryable<CatalogRuleCustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogRuleCustomerGroup> catalogRuleCustomerGroupList = await _catalogRuleCustomerGroupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogRuleCustomerGroupList;
    }

    public async Task<CatalogRuleCustomerGroup> AddAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup)
    {
        CatalogRuleCustomerGroup addedCatalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.AddAsync(catalogRuleCustomerGroup);

        return addedCatalogRuleCustomerGroup;
    }

    public async Task<CatalogRuleCustomerGroup> UpdateAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup)
    {
        CatalogRuleCustomerGroup updatedCatalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.UpdateAsync(catalogRuleCustomerGroup);

        return updatedCatalogRuleCustomerGroup;
    }

    public async Task<CatalogRuleCustomerGroup> DeleteAsync(CatalogRuleCustomerGroup catalogRuleCustomerGroup, bool permanent = false)
    {
        CatalogRuleCustomerGroup deletedCatalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.DeleteAsync(catalogRuleCustomerGroup);

        return deletedCatalogRuleCustomerGroup;
    }
}
