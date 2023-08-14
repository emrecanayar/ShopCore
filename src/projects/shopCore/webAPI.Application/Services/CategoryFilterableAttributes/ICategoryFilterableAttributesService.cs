using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryFilterableAttributes;

public interface ICategoryFilterableAttributesService
{
    Task<CategoryFilterableAttribute?> GetAsync(
        Expression<Func<CategoryFilterableAttribute, bool>> predicate,
        Func<IQueryable<CategoryFilterableAttribute>, IIncludableQueryable<CategoryFilterableAttribute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryFilterableAttribute>?> GetListAsync(
        Expression<Func<CategoryFilterableAttribute, bool>>? predicate = null,
        Func<IQueryable<CategoryFilterableAttribute>, IOrderedQueryable<CategoryFilterableAttribute>>? orderBy = null,
        Func<IQueryable<CategoryFilterableAttribute>, IIncludableQueryable<CategoryFilterableAttribute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryFilterableAttribute> AddAsync(CategoryFilterableAttribute categoryFilterableAttribute);
    Task<CategoryFilterableAttribute> UpdateAsync(CategoryFilterableAttribute categoryFilterableAttribute);
    Task<CategoryFilterableAttribute> DeleteAsync(CategoryFilterableAttribute categoryFilterableAttribute, bool permanent = false);
}
