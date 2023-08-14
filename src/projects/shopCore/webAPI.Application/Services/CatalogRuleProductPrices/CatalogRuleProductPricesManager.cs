using Application.Features.CatalogRuleProductPrices.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleProductPrices;

public class CatalogRuleProductPricesManager : ICatalogRuleProductPricesService
{
    private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
    private readonly CatalogRuleProductPriceBusinessRules _catalogRuleProductPriceBusinessRules;

    public CatalogRuleProductPricesManager(ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository, CatalogRuleProductPriceBusinessRules catalogRuleProductPriceBusinessRules)
    {
        _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
        _catalogRuleProductPriceBusinessRules = catalogRuleProductPriceBusinessRules;
    }

    public async Task<CatalogRuleProductPrice?> GetAsync(
        Expression<Func<CatalogRuleProductPrice, bool>> predicate,
        Func<IQueryable<CatalogRuleProductPrice>, IIncludableQueryable<CatalogRuleProductPrice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogRuleProductPrice? catalogRuleProductPrice = await _catalogRuleProductPriceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogRuleProductPrice;
    }

    public async Task<IPaginate<CatalogRuleProductPrice>?> GetListAsync(
        Expression<Func<CatalogRuleProductPrice, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleProductPrice>, IOrderedQueryable<CatalogRuleProductPrice>>? orderBy = null,
        Func<IQueryable<CatalogRuleProductPrice>, IIncludableQueryable<CatalogRuleProductPrice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogRuleProductPrice> catalogRuleProductPriceList = await _catalogRuleProductPriceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogRuleProductPriceList;
    }

    public async Task<CatalogRuleProductPrice> AddAsync(CatalogRuleProductPrice catalogRuleProductPrice)
    {
        CatalogRuleProductPrice addedCatalogRuleProductPrice = await _catalogRuleProductPriceRepository.AddAsync(catalogRuleProductPrice);

        return addedCatalogRuleProductPrice;
    }

    public async Task<CatalogRuleProductPrice> UpdateAsync(CatalogRuleProductPrice catalogRuleProductPrice)
    {
        CatalogRuleProductPrice updatedCatalogRuleProductPrice = await _catalogRuleProductPriceRepository.UpdateAsync(catalogRuleProductPrice);

        return updatedCatalogRuleProductPrice;
    }

    public async Task<CatalogRuleProductPrice> DeleteAsync(CatalogRuleProductPrice catalogRuleProductPrice, bool permanent = false)
    {
        CatalogRuleProductPrice deletedCatalogRuleProductPrice = await _catalogRuleProductPriceRepository.DeleteAsync(catalogRuleProductPrice);

        return deletedCatalogRuleProductPrice;
    }
}
