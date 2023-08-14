using Application.Features.AttributeGroupMappings.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.AttributeGroupMappings.Rules;

public class AttributeGroupMappingBusinessRules : BaseBusinessRules
{
    private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;

    public AttributeGroupMappingBusinessRules(IAttributeGroupMappingRepository attributeGroupMappingRepository)
    {
        _attributeGroupMappingRepository = attributeGroupMappingRepository;
    }

    public Task AttributeGroupMappingShouldExistWhenSelected(AttributeGroupMapping? attributeGroupMapping)
    {
        if (attributeGroupMapping == null)
            throw new BusinessException(AttributeGroupMappingsBusinessMessages.AttributeGroupMappingNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeGroupMappingIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AttributeGroupMapping? attributeGroupMapping = await _attributeGroupMappingRepository.GetAsync(
            predicate: agm => agm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeGroupMappingShouldExistWhenSelected(attributeGroupMapping);
    }
}