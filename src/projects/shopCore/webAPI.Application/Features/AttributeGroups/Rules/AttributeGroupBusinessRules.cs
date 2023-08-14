using Application.Features.AttributeGroups.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.AttributeGroups.Rules;

public class AttributeGroupBusinessRules : BaseBusinessRules
{
    private readonly IAttributeGroupRepository _attributeGroupRepository;

    public AttributeGroupBusinessRules(IAttributeGroupRepository attributeGroupRepository)
    {
        _attributeGroupRepository = attributeGroupRepository;
    }

    public Task AttributeGroupShouldExistWhenSelected(AttributeGroup? attributeGroup)
    {
        if (attributeGroup == null)
            throw new BusinessException(AttributeGroupsBusinessMessages.AttributeGroupNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeGroupIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AttributeGroup? attributeGroup = await _attributeGroupRepository.GetAsync(
            predicate: ag => ag.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeGroupShouldExistWhenSelected(attributeGroup);
    }
}