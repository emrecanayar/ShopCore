using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CatalogRuleRepository : EfRepositoryBase<CatalogRule, uint, BaseDbContext>, ICatalogRuleRepository
{
    public CatalogRuleRepository(BaseDbContext context) : base(context)
    {
    }
}