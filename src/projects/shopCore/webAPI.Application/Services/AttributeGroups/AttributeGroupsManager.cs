using Application.Features.AttributeGroups.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeGroups;

public class AttributeGroupsManager : IAttributeGroupsService
{
    private readonly IAttributeGroupRepository _attributeGroupRepository;
    private readonly AttributeGroupBusinessRules _attributeGroupBusinessRules;

    public AttributeGroupsManager(IAttributeGroupRepository attributeGroupRepository, AttributeGroupBusinessRules attributeGroupBusinessRules)
    {
        _attributeGroupRepository = attributeGroupRepository;
        _attributeGroupBusinessRules = attributeGroupBusinessRules;
    }

    public async Task<AttributeGroup?> GetAsync(
        Expression<Func<AttributeGroup, bool>> predicate,
        Func<IQueryable<AttributeGroup>, IIncludableQueryable<AttributeGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AttributeGroup? attributeGroup = await _attributeGroupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attributeGroup;
    }

    public async Task<IPaginate<AttributeGroup>?> GetListAsync(
        Expression<Func<AttributeGroup, bool>>? predicate = null,
        Func<IQueryable<AttributeGroup>, IOrderedQueryable<AttributeGroup>>? orderBy = null,
        Func<IQueryable<AttributeGroup>, IIncludableQueryable<AttributeGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AttributeGroup> attributeGroupList = await _attributeGroupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeGroupList;
    }

    public async Task<AttributeGroup> AddAsync(AttributeGroup attributeGroup)
    {
        AttributeGroup addedAttributeGroup = await _attributeGroupRepository.AddAsync(attributeGroup);

        return addedAttributeGroup;
    }

    public async Task<AttributeGroup> UpdateAsync(AttributeGroup attributeGroup)
    {
        AttributeGroup updatedAttributeGroup = await _attributeGroupRepository.UpdateAsync(attributeGroup);

        return updatedAttributeGroup;
    }

    public async Task<AttributeGroup> DeleteAsync(AttributeGroup attributeGroup, bool permanent = false)
    {
        AttributeGroup deletedAttributeGroup = await _attributeGroupRepository.DeleteAsync(attributeGroup);

        return deletedAttributeGroup;
    }
}
