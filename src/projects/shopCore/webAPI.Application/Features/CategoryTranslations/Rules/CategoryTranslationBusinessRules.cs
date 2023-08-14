using Application.Features.CategoryTranslations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CategoryTranslations.Rules;

public class CategoryTranslationBusinessRules : BaseBusinessRules
{
    private readonly ICategoryTranslationRepository _categoryTranslationRepository;

    public CategoryTranslationBusinessRules(ICategoryTranslationRepository categoryTranslationRepository)
    {
        _categoryTranslationRepository = categoryTranslationRepository;
    }

    public Task CategoryTranslationShouldExistWhenSelected(CategoryTranslation? categoryTranslation)
    {
        if (categoryTranslation == null)
            throw new BusinessException(CategoryTranslationsBusinessMessages.CategoryTranslationNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryTranslationIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CategoryTranslation? categoryTranslation = await _categoryTranslationRepository.GetAsync(
            predicate: ct => ct.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryTranslationShouldExistWhenSelected(categoryTranslation);
    }
}