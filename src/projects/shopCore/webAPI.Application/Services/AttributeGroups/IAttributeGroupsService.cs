using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeGroups;

public interface IAttributeGroupsService
{
    Task<AttributeGroup?> GetAsync(
        Expression<Func<AttributeGroup, bool>> predicate,
        Func<IQueryable<AttributeGroup>, IIncludableQueryable<AttributeGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AttributeGroup>?> GetListAsync(
        Expression<Func<AttributeGroup, bool>>? predicate = null,
        Func<IQueryable<AttributeGroup>, IOrderedQueryable<AttributeGroup>>? orderBy = null,
        Func<IQueryable<AttributeGroup>, IIncludableQueryable<AttributeGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AttributeGroup> AddAsync(AttributeGroup attributeGroup);
    Task<AttributeGroup> UpdateAsync(AttributeGroup attributeGroup);
    Task<AttributeGroup> DeleteAsync(AttributeGroup attributeGroup, bool permanent = false);
}
