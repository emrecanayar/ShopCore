using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeGroupMappings;

public interface IAttributeGroupMappingsService
{
    Task<AttributeGroupMapping?> GetAsync(
        Expression<Func<AttributeGroupMapping, bool>> predicate,
        Func<IQueryable<AttributeGroupMapping>, IIncludableQueryable<AttributeGroupMapping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AttributeGroupMapping>?> GetListAsync(
        Expression<Func<AttributeGroupMapping, bool>>? predicate = null,
        Func<IQueryable<AttributeGroupMapping>, IOrderedQueryable<AttributeGroupMapping>>? orderBy = null,
        Func<IQueryable<AttributeGroupMapping>, IIncludableQueryable<AttributeGroupMapping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AttributeGroupMapping> AddAsync(AttributeGroupMapping attributeGroupMapping);
    Task<AttributeGroupMapping> UpdateAsync(AttributeGroupMapping attributeGroupMapping);
    Task<AttributeGroupMapping> DeleteAsync(AttributeGroupMapping attributeGroupMapping, bool permanent = false);
}
