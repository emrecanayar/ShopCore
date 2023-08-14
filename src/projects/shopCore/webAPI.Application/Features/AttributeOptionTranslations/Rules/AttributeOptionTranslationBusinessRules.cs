using Application.Features.AttributeOptionTranslations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.AttributeOptionTranslations.Rules;

public class AttributeOptionTranslationBusinessRules : BaseBusinessRules
{
    private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;

    public AttributeOptionTranslationBusinessRules(IAttributeOptionTranslationRepository attributeOptionTranslationRepository)
    {
        _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
    }

    public Task AttributeOptionTranslationShouldExistWhenSelected(AttributeOptionTranslation? attributeOptionTranslation)
    {
        if (attributeOptionTranslation == null)
            throw new BusinessException(AttributeOptionTranslationsBusinessMessages.AttributeOptionTranslationNotExists);
        return Task.CompletedTask;
    }

    public async Task AttributeOptionTranslationIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AttributeOptionTranslation? attributeOptionTranslation = await _attributeOptionTranslationRepository.GetAsync(
            predicate: aot => aot.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttributeOptionTranslationShouldExistWhenSelected(attributeOptionTranslation);
    }
}