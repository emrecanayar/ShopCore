using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryTranslations;

public interface ICategoryTranslationsService
{
    Task<CategoryTranslation?> GetAsync(
        Expression<Func<CategoryTranslation, bool>> predicate,
        Func<IQueryable<CategoryTranslation>, IIncludableQueryable<CategoryTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryTranslation>?> GetListAsync(
        Expression<Func<CategoryTranslation, bool>>? predicate = null,
        Func<IQueryable<CategoryTranslation>, IOrderedQueryable<CategoryTranslation>>? orderBy = null,
        Func<IQueryable<CategoryTranslation>, IIncludableQueryable<CategoryTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryTranslation> AddAsync(CategoryTranslation categoryTranslation);
    Task<CategoryTranslation> UpdateAsync(CategoryTranslation categoryTranslation);
    Task<CategoryTranslation> DeleteAsync(CategoryTranslation categoryTranslation, bool permanent = false);
}
