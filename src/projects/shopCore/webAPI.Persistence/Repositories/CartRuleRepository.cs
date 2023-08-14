using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleRepository : EfRepositoryBase<CartRule, uint, BaseDbContext>, ICartRuleRepository
{
    public CartRuleRepository(BaseDbContext context) : base(context)
    {
    }
}