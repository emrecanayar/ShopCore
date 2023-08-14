using Application.Features.CatalogRuleCustomerGroups.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CatalogRuleCustomerGroups.Rules;

public class CatalogRuleCustomerGroupBusinessRules : BaseBusinessRules
{
    private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;

    public CatalogRuleCustomerGroupBusinessRules(ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository)
    {
        _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
    }

    public Task CatalogRuleCustomerGroupShouldExistWhenSelected(CatalogRuleCustomerGroup? catalogRuleCustomerGroup)
    {
        if (catalogRuleCustomerGroup == null)
            throw new BusinessException(CatalogRuleCustomerGroupsBusinessMessages.CatalogRuleCustomerGroupNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogRuleCustomerGroupIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CatalogRuleCustomerGroup? catalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.GetAsync(
            predicate: crcg => crcg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogRuleCustomerGroupShouldExistWhenSelected(catalogRuleCustomerGroup);
    }
}