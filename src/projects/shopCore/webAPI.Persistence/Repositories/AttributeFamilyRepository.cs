using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AttributeFamilyRepository : EfRepositoryBase<AttributeFamily, uint, BaseDbContext>, IAttributeFamilyRepository
{
    public AttributeFamilyRepository(BaseDbContext context) : base(context)
    {
    }
}