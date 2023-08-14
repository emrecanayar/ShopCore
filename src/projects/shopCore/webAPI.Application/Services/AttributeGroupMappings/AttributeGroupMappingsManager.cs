using Application.Features.AttributeGroupMappings.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeGroupMappings;

public class AttributeGroupMappingsManager : IAttributeGroupMappingsService
{
    private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
    private readonly AttributeGroupMappingBusinessRules _attributeGroupMappingBusinessRules;

    public AttributeGroupMappingsManager(IAttributeGroupMappingRepository attributeGroupMappingRepository, AttributeGroupMappingBusinessRules attributeGroupMappingBusinessRules)
    {
        _attributeGroupMappingRepository = attributeGroupMappingRepository;
        _attributeGroupMappingBusinessRules = attributeGroupMappingBusinessRules;
    }

    public async Task<AttributeGroupMapping?> GetAsync(
        Expression<Func<AttributeGroupMapping, bool>> predicate,
        Func<IQueryable<AttributeGroupMapping>, IIncludableQueryable<AttributeGroupMapping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AttributeGroupMapping? attributeGroupMapping = await _attributeGroupMappingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attributeGroupMapping;
    }

    public async Task<IPaginate<AttributeGroupMapping>?> GetListAsync(
        Expression<Func<AttributeGroupMapping, bool>>? predicate = null,
        Func<IQueryable<AttributeGroupMapping>, IOrderedQueryable<AttributeGroupMapping>>? orderBy = null,
        Func<IQueryable<AttributeGroupMapping>, IIncludableQueryable<AttributeGroupMapping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AttributeGroupMapping> attributeGroupMappingList = await _attributeGroupMappingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeGroupMappingList;
    }

    public async Task<AttributeGroupMapping> AddAsync(AttributeGroupMapping attributeGroupMapping)
    {
        AttributeGroupMapping addedAttributeGroupMapping = await _attributeGroupMappingRepository.AddAsync(attributeGroupMapping);

        return addedAttributeGroupMapping;
    }

    public async Task<AttributeGroupMapping> UpdateAsync(AttributeGroupMapping attributeGroupMapping)
    {
        AttributeGroupMapping updatedAttributeGroupMapping = await _attributeGroupMappingRepository.UpdateAsync(attributeGroupMapping);

        return updatedAttributeGroupMapping;
    }

    public async Task<AttributeGroupMapping> DeleteAsync(AttributeGroupMapping attributeGroupMapping, bool permanent = false)
    {
        AttributeGroupMapping deletedAttributeGroupMapping = await _attributeGroupMappingRepository.DeleteAsync(attributeGroupMapping);

        return deletedAttributeGroupMapping;
    }
}
