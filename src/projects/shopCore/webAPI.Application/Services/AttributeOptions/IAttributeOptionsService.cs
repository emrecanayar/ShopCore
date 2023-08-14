using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeOptions;

public interface IAttributeOptionsService
{
    Task<AttributeOption?> GetAsync(
        Expression<Func<AttributeOption, bool>> predicate,
        Func<IQueryable<AttributeOption>, IIncludableQueryable<AttributeOption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AttributeOption>?> GetListAsync(
        Expression<Func<AttributeOption, bool>>? predicate = null,
        Func<IQueryable<AttributeOption>, IOrderedQueryable<AttributeOption>>? orderBy = null,
        Func<IQueryable<AttributeOption>, IIncludableQueryable<AttributeOption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AttributeOption> AddAsync(AttributeOption attributeOption);
    Task<AttributeOption> UpdateAsync(AttributeOption attributeOption);
    Task<AttributeOption> DeleteAsync(AttributeOption attributeOption, bool permanent = false);
}
