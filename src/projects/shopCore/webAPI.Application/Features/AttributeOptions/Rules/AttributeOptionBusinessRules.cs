using Application.Features.AttributeOptions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.AttributeOptions.Rules;

public class AttributeOptionBusinessRules : BaseBusinessRules
{
    private readonly IAttributeOptionRepository _attributeOptionRepository;

    public AttributeOptionBusinessRules(IAttributeOptionRepository attributeOptionRepository)
    {
        _attributeOptionRepository = attributeOptionRepository;
    }

    public Task AttributeOptionShouldExistWhenSelected(AttributeOption? attributeOption)
    {
        if (attributeOption == null)
            throw new BusinessException(AttributeOptionsBusinessMessages.AttributeOptionNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeOptionIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AttributeOption? attributeOption = await _attributeOptionRepository.GetAsync(
            predicate: ao => ao.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeOptionShouldExistWhenSelected(attributeOption);
    }
}