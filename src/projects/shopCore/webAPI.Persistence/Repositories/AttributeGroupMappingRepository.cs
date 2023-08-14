using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AttributeGroupMappingRepository : EfRepositoryBase<AttributeGroupMapping, uint, BaseDbContext>, IAttributeGroupMappingRepository
{
    public AttributeGroupMappingRepository(BaseDbContext context) : base(context)
    {
    }
}