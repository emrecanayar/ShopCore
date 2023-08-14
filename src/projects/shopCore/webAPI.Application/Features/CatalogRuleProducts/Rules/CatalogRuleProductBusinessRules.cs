using Application.Features.CatalogRuleProducts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CatalogRuleProducts.Rules;

public class CatalogRuleProductBusinessRules : BaseBusinessRules
{
    private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;

    public CatalogRuleProductBusinessRules(ICatalogRuleProductRepository catalogRuleProductRepository)
    {
        _catalogRuleProductRepository = catalogRuleProductRepository;
    }

    public Task CatalogRuleProductShouldExistWhenSelected(CatalogRuleProduct? catalogRuleProduct)
    {
        if (catalogRuleProduct == null)
            throw new BusinessException(CatalogRuleProductsBusinessMessages.CatalogRuleProductNotExists);
        return Task.CompletedTask;
    }

    public async Task CatalogRuleProductIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CatalogRuleProduct? catalogRuleProduct = await _catalogRuleProductRepository.GetAsync(
            predicate: crp => crp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CatalogRuleProductShouldExistWhenSelected(catalogRuleProduct);
    }
}