using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CatalogRuleProductRepository : EfRepositoryBase<CatalogRuleProduct, uint, BaseDbContext>, ICatalogRuleProductRepository
{
    public CatalogRuleProductRepository(BaseDbContext context) : base(context)
    {
    }
}