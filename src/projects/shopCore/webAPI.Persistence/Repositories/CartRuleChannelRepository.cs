using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleChannelRepository : EfRepositoryBase<CartRuleChannel, uint, BaseDbContext>, ICartRuleChannelRepository
{
    public CartRuleChannelRepository(BaseDbContext context) : base(context)
    {
    }
}