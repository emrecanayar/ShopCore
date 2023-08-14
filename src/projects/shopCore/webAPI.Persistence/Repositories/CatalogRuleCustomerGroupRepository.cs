using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CatalogRuleCustomerGroupRepository : EfRepositoryBase<CatalogRuleCustomerGroup, uint, BaseDbContext>, ICatalogRuleCustomerGroupRepository
{
    public CatalogRuleCustomerGroupRepository(BaseDbContext context) : base(context)
    {
    }
}