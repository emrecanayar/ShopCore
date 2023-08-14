using Application.Features.Attributes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Services.Attributes;

public class AttributesManager : IAttributesService
{
    private readonly IAttributeRepository _attributeRepository;
    private readonly AttributeBusinessRules _attributeBusinessRules;

    public AttributesManager(IAttributeRepository attributeRepository, AttributeBusinessRules attributeBusinessRules)
    {
        _attributeRepository = attributeRepository;
        _attributeBusinessRules = attributeBusinessRules;
    }

    public async Task<Attribute?> GetAsync(
        Expression<Func<Attribute, bool>> predicate,
        Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Attribute? attribute = await _attributeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attribute;
    }

    public async Task<IPaginate<Attribute>?> GetListAsync(
        Expression<Func<Attribute, bool>>? predicate = null,
        Func<IQueryable<Attribute>, IOrderedQueryable<Attribute>>? orderBy = null,
        Func<IQueryable<Attribute>, IIncludableQueryable<Attribute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Attribute> attributeList = await _attributeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attributeList;
    }

    public async Task<Attribute> AddAsync(Attribute attribute)
    {
        Attribute addedAttribute = await _attributeRepository.AddAsync(attribute);

        return addedAttribute;
    }

    public async Task<Attribute> UpdateAsync(Attribute attribute)
    {
        Attribute updatedAttribute = await _attributeRepository.UpdateAsync(attribute);

        return updatedAttribute;
    }

    public async Task<Attribute> DeleteAsync(Attribute attribute, bool permanent = false)
    {
        Attribute deletedAttribute = await _attributeRepository.DeleteAsync(attribute);

        return deletedAttribute;
    }
}
