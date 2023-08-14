using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AttributeGroupRepository : EfRepositoryBase<AttributeGroup, uint, BaseDbContext>, IAttributeGroupRepository
{
    public AttributeGroupRepository(BaseDbContext context) : base(context)
    {
    }
}