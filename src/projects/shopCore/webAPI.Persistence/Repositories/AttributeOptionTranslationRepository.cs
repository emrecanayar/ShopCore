using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AttributeOptionTranslationRepository : EfRepositoryBase<AttributeOptionTranslation, uint, BaseDbContext>, IAttributeOptionTranslationRepository
{
    public AttributeOptionTranslationRepository(BaseDbContext context) : base(context)
    {
    }
}