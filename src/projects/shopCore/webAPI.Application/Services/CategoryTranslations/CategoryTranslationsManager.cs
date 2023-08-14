using Application.Features.CategoryTranslations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryTranslations;

public class CategoryTranslationsManager : ICategoryTranslationsService
{
    private readonly ICategoryTranslationRepository _categoryTranslationRepository;
    private readonly CategoryTranslationBusinessRules _categoryTranslationBusinessRules;

    public CategoryTranslationsManager(ICategoryTranslationRepository categoryTranslationRepository, CategoryTranslationBusinessRules categoryTranslationBusinessRules)
    {
        _categoryTranslationRepository = categoryTranslationRepository;
        _categoryTranslationBusinessRules = categoryTranslationBusinessRules;
    }

    public async Task<CategoryTranslation?> GetAsync(
        Expression<Func<CategoryTranslation, bool>> predicate,
        Func<IQueryable<CategoryTranslation>, IIncludableQueryable<CategoryTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryTranslation? categoryTranslation = await _categoryTranslationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryTranslation;
    }

    public async Task<IPaginate<CategoryTranslation>?> GetListAsync(
        Expression<Func<CategoryTranslation, bool>>? predicate = null,
        Func<IQueryable<CategoryTranslation>, IOrderedQueryable<CategoryTranslation>>? orderBy = null,
        Func<IQueryable<CategoryTranslation>, IIncludableQueryable<CategoryTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryTranslation> categoryTranslationList = await _categoryTranslationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryTranslationList;
    }

    public async Task<CategoryTranslation> AddAsync(CategoryTranslation categoryTranslation)
    {
        CategoryTranslation addedCategoryTranslation = await _categoryTranslationRepository.AddAsync(categoryTranslation);

        return addedCategoryTranslation;
    }

    public async Task<CategoryTranslation> UpdateAsync(CategoryTranslation categoryTranslation)
    {
        CategoryTranslation updatedCategoryTranslation = await _categoryTranslationRepository.UpdateAsync(categoryTranslation);

        return updatedCategoryTranslation;
    }

    public async Task<CategoryTranslation> DeleteAsync(CategoryTranslation categoryTranslation, bool permanent = false)
    {
        CategoryTranslation deletedCategoryTranslation = await _categoryTranslationRepository.DeleteAsync(categoryTranslation);

        return deletedCategoryTranslation;
    }
}
