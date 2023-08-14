using Application.Features.Attributes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Attributes.Rules;

public class AttributeBusinessRules : BaseBusinessRules
{
    private readonly IAttributeRepository _attributeRepository;

    public AttributeBusinessRules(IAttributeRepository attributeRepository)
    {
        _attributeRepository = attributeRepository;
    }

    public Task AttributeShouldExistWhenSelected(Core.Domain.Entities.Attribute? attribute)
    {
        if (attribute == null)
            throw new BusinessException(AttributesBusinessMessages.AttributeNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Core.Domain.Entities.Attribute? attribute = await _attributeRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeShouldExistWhenSelected(attribute);
    }
}