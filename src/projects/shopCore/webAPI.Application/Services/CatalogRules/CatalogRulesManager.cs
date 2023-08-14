using Application.Features.CatalogRules.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CatalogRules;

public class CatalogRulesManager : ICatalogRulesService
{
    private readonly ICatalogRuleRepository _catalogRuleRepository;
    private readonly CatalogRuleBusinessRules _catalogRuleBusinessRules;

    public CatalogRulesManager(ICatalogRuleRepository catalogRuleRepository, CatalogRuleBusinessRules catalogRuleBusinessRules)
    {
        _catalogRuleRepository = catalogRuleRepository;
        _catalogRuleBusinessRules = catalogRuleBusinessRules;
    }

    public async Task<CatalogRule?> GetAsync(
        Expression<Func<CatalogRule, bool>> predicate,
        Func<IQueryable<CatalogRule>, IIncludableQueryable<CatalogRule, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CatalogRule? catalogRule = await _catalogRuleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return catalogRule;
    }

    public async Task<IPaginate<CatalogRule>?> GetListAsync(
        Expression<Func<CatalogRule, bool>>? predicate = null,
        Func<IQueryable<CatalogRule>, IOrderedQueryable<CatalogRule>>? orderBy = null,
        Func<IQueryable<CatalogRule>, IIncludableQueryable<CatalogRule, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CatalogRule> catalogRuleList = await _catalogRuleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return catalogRuleList;
    }

    public async Task<CatalogRule> AddAsync(CatalogRule catalogRule)
    {
        CatalogRule addedCatalogRule = await _catalogRuleRepository.AddAsync(catalogRule);

        return addedCatalogRule;
    }

    public async Task<CatalogRule> UpdateAsync(CatalogRule catalogRule)
    {
        CatalogRule updatedCatalogRule = await _catalogRuleRepository.UpdateAsync(catalogRule);

        return updatedCatalogRule;
    }

    public async Task<CatalogRule> DeleteAsync(CatalogRule catalogRule, bool permanent = false)
    {
        CatalogRule deletedCatalogRule = await _catalogRuleRepository.DeleteAsync(catalogRule);

        return deletedCatalogRule;
    }
}
