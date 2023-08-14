using Application.Features.CatalogRuleProductPrices.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CatalogRuleProductPrices.Rules;

public class CatalogRuleProductPriceBusinessRules : BaseBusinessRules
{
    private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;

    public CatalogRuleProductPriceBusinessRules(ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository)
    {
        _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
    }

    public Task CatalogRuleProductPriceShouldExistWhenSelected(CatalogRuleProductPrice? catalogRuleProductPrice)
    {
        if (catalogRuleProductPrice == null)
            throw new BusinessException(CatalogRuleProductPricesBusinessMessages.CatalogRuleProductPriceNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogRuleProductPriceIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CatalogRuleProductPrice? catalogRuleProductPrice = await _catalogRuleProductPriceRepository.GetAsync(
            predicate: crpp => crpp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogRuleProductPriceShouldExistWhenSelected(catalogRuleProductPrice);
    }
}