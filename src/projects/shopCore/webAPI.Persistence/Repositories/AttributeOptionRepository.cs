using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AttributeOptionRepository : EfRepositoryBase<AttributeOption, uint, BaseDbContext>, IAttributeOptionRepository
{
    public AttributeOptionRepository(BaseDbContext context) : base(context)
    {
    }
}