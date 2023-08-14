using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeFamilies;

public interface IAttributeFamiliesService
{
    Task<AttributeFamily?> GetAsync(
        Expression<Func<AttributeFamily, bool>> predicate,
        Func<IQueryable<AttributeFamily>, IIncludableQueryable<AttributeFamily, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AttributeFamily>?> GetListAsync(
        Expression<Func<AttributeFamily, bool>>? predicate = null,
        Func<IQueryable<AttributeFamily>, IOrderedQueryable<AttributeFamily>>? orderBy = null,
        Func<IQueryable<AttributeFamily>, IIncludableQueryable<AttributeFamily, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AttributeFamily> AddAsync(AttributeFamily attributeFamily);
    Task<AttributeFamily> UpdateAsync(AttributeFamily attributeFamily);
    Task<AttributeFamily> DeleteAsync(AttributeFamily attributeFamily, bool permanent = false);
}
