using Application.Services.Repositories;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using Attribute = Core.Domain.Entities.Attribute;

namespace Persistence.Repositories;

public class AttributeRepository : EfRepositoryBase<Attribute, uint, BaseDbContext>, IAttributeRepository
{
    public AttributeRepository(BaseDbContext context) : base(context)
    {
    }
}