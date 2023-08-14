using Application.Features.AttributeFamilies.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeFamilies;

public class AttributeFamiliesManager : IAttributeFamiliesService
{
    private readonly IAttributeFamilyRepository _attributeFamilyRepository;
    private readonly AttributeFamilyBusinessRules _attributeFamilyBusinessRules;

    public AttributeFamiliesManager(IAttributeFamilyRepository attributeFamilyRepository, AttributeFamilyBusinessRules attributeFamilyBusinessRules)
    {
        _attributeFamilyRepository = attributeFamilyRepository;
        _attributeFamilyBusinessRules = attributeFamilyBusinessRules;
    }

    public async Task<AttributeFamily?> GetAsync(
        Expression<Func<AttributeFamily, bool>> predicate,
        Func<IQueryable<AttributeFamily>, IIncludableQueryable<AttributeFamily, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AttributeFamily? attributeFamily = await _attributeFamilyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attributeFamily;
    }

    public async Task<IPaginate<AttributeFamily>?> GetListAsync(
        Expression<Func<AttributeFamily, bool>>? predicate = null,
        Func<IQueryable<AttributeFamily>, IOrderedQueryable<AttributeFamily>>? orderBy = null,
        Func<IQueryable<AttributeFamily>, IIncludableQueryable<AttributeFamily, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AttributeFamily> attributeFamilyList = await _attributeFamilyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeFamilyList;
    }

    public async Task<AttributeFamily> AddAsync(AttributeFamily attributeFamily)
    {
        AttributeFamily addedAttributeFamily = await _attributeFamilyRepository.AddAsync(attributeFamily);

        return addedAttributeFamily;
    }

    public async Task<AttributeFamily> UpdateAsync(AttributeFamily attributeFamily)
    {
        AttributeFamily updatedAttributeFamily = await _attributeFamilyRepository.UpdateAsync(attributeFamily);

        return updatedAttributeFamily;
    }

    public async Task<AttributeFamily> DeleteAsync(AttributeFamily attributeFamily, bool permanent = false)
    {
        AttributeFamily deletedAttributeFamily = await _attributeFamilyRepository.DeleteAsync(attributeFamily);

        return deletedAttributeFamily;
    }
}
