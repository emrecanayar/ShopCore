using Application.Features.CategoryFilterableAttributes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryFilterableAttributes;

public class CategoryFilterableAttributesManager : ICategoryFilterableAttributesService
{
    private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
    private readonly CategoryFilterableAttributeBusinessRules _categoryFilterableAttributeBusinessRules;

    public CategoryFilterableAttributesManager(ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository, CategoryFilterableAttributeBusinessRules categoryFilterableAttributeBusinessRules)
    {
        _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
        _categoryFilterableAttributeBusinessRules = categoryFilterableAttributeBusinessRules;
    }

    public async Task<CategoryFilterableAttribute?> GetAsync(
        Expression<Func<CategoryFilterableAttribute, bool>> predicate,
        Func<IQueryable<CategoryFilterableAttribute>, IIncludableQueryable<CategoryFilterableAttribute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryFilterableAttribute? categoryFilterableAttribute = await _categoryFilterableAttributeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryFilterableAttribute;
    }

    public async Task<IPaginate<CategoryFilterableAttribute>?> GetListAsync(
        Expression<Func<CategoryFilterableAttribute, bool>>? predicate = null,
        Func<IQueryable<CategoryFilterableAttribute>, IOrderedQueryable<CategoryFilterableAttribute>>? orderBy = null,
        Func<IQueryable<CategoryFilterableAttribute>, IIncludableQueryable<CategoryFilterableAttribute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryFilterableAttribute> categoryFilterableAttributeList = await _categoryFilterableAttributeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryFilterableAttributeList;
    }

    public async Task<CategoryFilterableAttribute> AddAsync(CategoryFilterableAttribute categoryFilterableAttribute)
    {
        CategoryFilterableAttribute addedCategoryFilterableAttribute = await _categoryFilterableAttributeRepository.AddAsync(categoryFilterableAttribute);

        return addedCategoryFilterableAttribute;
    }

    public async Task<CategoryFilterableAttribute> UpdateAsync(CategoryFilterableAttribute categoryFilterableAttribute)
    {
        CategoryFilterableAttribute updatedCategoryFilterableAttribute = await _categoryFilterableAttributeRepository.UpdateAsync(categoryFilterableAttribute);

        return updatedCategoryFilterableAttribute;
    }

    public async Task<CategoryFilterableAttribute> DeleteAsync(CategoryFilterableAttribute categoryFilterableAttribute, bool permanent = false)
    {
        CategoryFilterableAttribute deletedCategoryFilterableAttribute = await _categoryFilterableAttributeRepository.DeleteAsync(categoryFilterableAttribute);

        return deletedCategoryFilterableAttribute;
    }
}
