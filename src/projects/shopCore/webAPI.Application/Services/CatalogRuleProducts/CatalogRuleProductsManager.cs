using Application.Features.CatalogRuleProducts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRuleProducts;

public class CatalogRuleProductsManager : ICatalogRuleProductsService
{
    private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
    private readonly CatalogRuleProductBusinessRules _catalogRuleProductBusinessRules;

    public CatalogRuleProductsManager(ICatalogRuleProductRepository catalogRuleProductRepository, CatalogRuleProductBusinessRules catalogRuleProductBusinessRules)
    {
        _catalogRuleProductRepository = catalogRuleProductRepository;
        _catalogRuleProductBusinessRules = catalogRuleProductBusinessRules;
    }

    public async Task<CatalogRuleProduct?> GetAsync(
        Expression<Func<CatalogRuleProduct, bool>> predicate,
        Func<IQueryable<CatalogRuleProduct>, IIncludableQueryable<CatalogRuleProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogRuleProduct? catalogRuleProduct = await _catalogRuleProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogRuleProduct;
    }

    public async Task<IPaginate<CatalogRuleProduct>?> GetListAsync(
        Expression<Func<CatalogRuleProduct, bool>>? predicate = null,
        Func<IQueryable<CatalogRuleProduct>, IOrderedQueryable<CatalogRuleProduct>>? orderBy = null,
        Func<IQueryable<CatalogRuleProduct>, IIncludableQueryable<CatalogRuleProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogRuleProduct> catalogRuleProductList = await _catalogRuleProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogRuleProductList;
    }

    public async Task<CatalogRuleProduct> AddAsync(CatalogRuleProduct catalogRuleProduct)
    {
        CatalogRuleProduct addedCatalogRuleProduct = await _catalogRuleProductRepository.AddAsync(catalogRuleProduct);

        return addedCatalogRuleProduct;
    }

    public async Task<CatalogRuleProduct> UpdateAsync(CatalogRuleProduct catalogRuleProduct)
    {
        CatalogRuleProduct updatedCatalogRuleProduct = await _catalogRuleProductRepository.UpdateAsync(catalogRuleProduct);

        return updatedCatalogRuleProduct;
    }

    public async Task<CatalogRuleProduct> DeleteAsync(CatalogRuleProduct catalogRuleProduct, bool permanent = false)
    {
        CatalogRuleProduct deletedCatalogRuleProduct = await _catalogRuleProductRepository.DeleteAsync(catalogRuleProduct);

        return deletedCatalogRuleProduct;
    }
}
