using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CatalogRuleChannelRepository : EfRepositoryBase<CatalogRuleChannel, uint, BaseDbContext>, ICatalogRuleChannelRepository
{
    public CatalogRuleChannelRepository(BaseDbContext context) : base(context)
    {
    }
}