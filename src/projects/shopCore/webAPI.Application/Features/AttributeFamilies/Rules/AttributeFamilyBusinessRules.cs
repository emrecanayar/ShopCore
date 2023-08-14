using Application.Features.AttributeFamilies.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.AttributeFamilies.Rules;

public class AttributeFamilyBusinessRules : BaseBusinessRules
{
    private readonly IAttributeFamilyRepository _attributeFamilyRepository;

    public AttributeFamilyBusinessRules(IAttributeFamilyRepository attributeFamilyRepository)
    {
        _attributeFamilyRepository = attributeFamilyRepository;
    }

    public Task AttributeFamilyShouldExistWhenSelected(AttributeFamily? attributeFamily)
    {
        if (attributeFamily == null)
            throw new BusinessException(AttributeFamiliesBusinessMessages.AttributeFamilyNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeFamilyIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AttributeFamily? attributeFamily = await _attributeFamilyRepository.GetAsync(
            predicate: af => af.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeFamilyShouldExistWhenSelected(attributeFamily);
    }
}