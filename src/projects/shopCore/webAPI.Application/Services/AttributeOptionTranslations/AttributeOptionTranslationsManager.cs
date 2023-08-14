using Application.Features.AttributeOptionTranslations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeOptionTranslations;

public class AttributeOptionTranslationsManager : IAttributeOptionTranslationsService
{
    private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
    private readonly AttributeOptionTranslationBusinessRules _attributeOptionTranslationBusinessRules;

    public AttributeOptionTranslationsManager(IAttributeOptionTranslationRepository attributeOptionTranslationRepository, AttributeOptionTranslationBusinessRules attributeOptionTranslationBusinessRules)
    {
        _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
        _attributeOptionTranslationBusinessRules = attributeOptionTranslationBusinessRules;
    }

    public async Task<AttributeOptionTranslation?> GetAsync(
        Expression<Func<AttributeOptionTranslation, bool>> predicate,
        Func<IQueryable<AttributeOptionTranslation>, IIncludableQueryable<AttributeOptionTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AttributeOptionTranslation? attributeOptionTranslation = await _attributeOptionTranslationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attributeOptionTranslation;
    }

    public async Task<IPaginate<AttributeOptionTranslation>?> GetListAsync(
        Expression<Func<AttributeOptionTranslation, bool>>? predicate = null,
        Func<IQueryable<AttributeOptionTranslation>, IOrderedQueryable<AttributeOptionTranslation>>? orderBy = null,
        Func<IQueryable<AttributeOptionTranslation>, IIncludableQueryable<AttributeOptionTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AttributeOptionTranslation> attributeOptionTranslationList = await _attributeOptionTranslationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeOptionTranslationList;
    }

    public async Task<AttributeOptionTranslation> AddAsync(AttributeOptionTranslation attributeOptionTranslation)
    {
        AttributeOptionTranslation addedAttributeOptionTranslation = await _attributeOptionTranslationRepository.AddAsync(attributeOptionTranslation);

        return addedAttributeOptionTranslation;
    }

    public async Task<AttributeOptionTranslation> UpdateAsync(AttributeOptionTranslation attributeOptionTranslation)
    {
        AttributeOptionTranslation updatedAttributeOptionTranslation = await _attributeOptionTranslationRepository.UpdateAsync(attributeOptionTranslation);

        return updatedAttributeOptionTranslation;
    }

    public async Task<AttributeOptionTranslation> DeleteAsync(AttributeOptionTranslation attributeOptionTranslation, bool permanent = false)
    {
        AttributeOptionTranslation deletedAttributeOptionTranslation = await _attributeOptionTranslationRepository.DeleteAsync(attributeOptionTranslation);

        return deletedAttributeOptionTranslation;
    }
}
