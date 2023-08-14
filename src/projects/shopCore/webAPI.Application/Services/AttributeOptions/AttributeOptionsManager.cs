using Application.Features.AttributeOptions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AttributeOptions;

public class AttributeOptionsManager : IAttributeOptionsService
{
    private readonly IAttributeOptionRepository _attributeOptionRepository;
    private readonly AttributeOptionBusinessRules _attributeOptionBusinessRules;

    public AttributeOptionsManager(IAttributeOptionRepository attributeOptionRepository, AttributeOptionBusinessRules attributeOptionBusinessRules)
    {
        _attributeOptionRepository = attributeOptionRepository;
        _attributeOptionBusinessRules = attributeOptionBusinessRules;
    }

    public async Task<AttributeOption?> GetAsync(
        Expression<Func<AttributeOption, bool>> predicate,
        Func<IQueryable<AttributeOption>, IIncludableQueryable<AttributeOption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AttributeOption? attributeOption = await _attributeOptionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attributeOption;
    }

    public async Task<IPaginate<AttributeOption>?> GetListAsync(
        Expression<Func<AttributeOption, bool>>? predicate = null,
        Func<IQueryable<AttributeOption>, IOrderedQueryable<AttributeOption>>? orderBy = null,
        Func<IQueryable<AttributeOption>, IIncludableQueryable<AttributeOption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AttributeOption> attributeOptionList = await _attributeOptionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeOptionList;
    }

    public async Task<AttributeOption> AddAsync(AttributeOption attributeOption)
    {
        AttributeOption addedAttributeOption = await _attributeOptionRepository.AddAsync(attributeOption);

        return addedAttributeOption;
    }

    public async Task<AttributeOption> UpdateAsync(AttributeOption attributeOption)
    {
        AttributeOption updatedAttributeOption = await _attributeOptionRepository.UpdateAsync(attributeOption);

        return updatedAttributeOption;
    }

    public async Task<AttributeOption> DeleteAsync(AttributeOption attributeOption, bool permanent = false)
    {
        AttributeOption deletedAttributeOption = await _attributeOptionRepository.DeleteAsync(attributeOption);

        return deletedAttributeOption;
    }
}
