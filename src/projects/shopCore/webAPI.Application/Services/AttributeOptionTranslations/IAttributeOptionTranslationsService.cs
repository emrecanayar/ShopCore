using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeOptionTranslations;

public interface IAttributeOptionTranslationsService
{
    Task<AttributeOptionTranslation?> GetAsync(
        Expression<Func<AttributeOptionTranslation, bool>> predicate,
        Func<IQueryable<AttributeOptionTranslation>, IIncludableQueryable<AttributeOptionTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AttributeOptionTranslation>?> GetListAsync(
        Expression<Func<AttributeOptionTranslation, bool>>? predicate = null,
        Func<IQueryable<AttributeOptionTranslation>, IOrderedQueryable<AttributeOptionTranslation>>? orderBy = null,
        Func<IQueryable<AttributeOptionTranslation>, IIncludableQueryable<AttributeOptionTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AttributeOptionTranslation> AddAsync(AttributeOptionTranslation attributeOptionTranslation);
    Task<AttributeOptionTranslation> UpdateAsync(AttributeOptionTranslation attributeOptionTranslation);
    Task<AttributeOptionTranslation> DeleteAsync(AttributeOptionTranslation attributeOptionTranslation, bool permanent = false);
}
