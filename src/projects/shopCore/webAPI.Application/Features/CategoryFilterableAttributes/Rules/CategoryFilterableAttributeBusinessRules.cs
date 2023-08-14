using Application.Features.CategoryFilterableAttributes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CategoryFilterableAttributes.Rules;

public class CategoryFilterableAttributeBusinessRules : BaseBusinessRules
{
    private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;

    public CategoryFilterableAttributeBusinessRules(ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository)
    {
        _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
    }

    public Task CategoryFilterableAttributeShouldExistWhenSelected(CategoryFilterableAttribute? categoryFilterableAttribute)
    {
        if (categoryFilterableAttribute == null)
            throw new BusinessException(CategoryFilterableAttributesBusinessMessages.CategoryFilterableAttributeNotExists);
        return Task.CompletedTask;
    }

    public async Task CategoryFilterableAttributeIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CategoryFilterableAttribute? categoryFilterableAttribute = await _categoryFilterableAttributeRepository.GetAsync(
            predicate: cfa => cfa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryFilterableAttributeShouldExistWhenSelected(categoryFilterableAttribute);
    }
}