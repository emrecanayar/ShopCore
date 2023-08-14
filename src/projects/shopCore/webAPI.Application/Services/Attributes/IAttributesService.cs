using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Services.Attributes;

public interface IAttributesService
{
    Task<Attribute?> GetAsync(
        Expression<Func<Attribute, bool>> predicate,
        Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Attribute>?> GetListAsync(
        Expression<Func<Attribute, bool>>? predicate = null,
        Func<IQueryable<Attribute>, IOrderedQueryable<Attribute>>? orderBy = null,
        Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Attribute> AddAsync(Attribute attribute);
    Task<Attribute> UpdateAsync(Attribute attribute);
    Task<Attribute> DeleteAsync(Attribute attribute, bool permanent = false);
}
