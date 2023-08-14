using Application.Features.CatalogRules.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CatalogRules.Rules;

public class CatalogRuleBusinessRules : BaseBusinessRules
{
    private readonly ICatalogRuleRepository _catalogRuleRepository;

    public CatalogRuleBusinessRules(ICatalogRuleRepository catalogRuleRepository)
    {
        _catalogRuleRepository = catalogRuleRepository;
    }

    public Task CatalogRuleShouldExistWhenSelected(CatalogRule? catalogRule)
    {
        if (catalogRule == null)
            throw new BusinessException(CatalogRulesBusinessMessages.CatalogRuleNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogRuleIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CatalogRule? catalogRule = await _catalogRuleRepository.GetAsync(
            predicate: cr => cr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogRuleShouldExistWhenSelected(catalogRule);
    }
}