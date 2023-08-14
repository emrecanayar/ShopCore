using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CatalogRuleProductPriceRepository : EfRepositoryBase<CatalogRuleProductPrice, uint, BaseDbContext>, ICatalogRuleProductPriceRepository
{
    public CatalogRuleProductPriceRepository(BaseDbContext context) : base(context)
    {
    }
}