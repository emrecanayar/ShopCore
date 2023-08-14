using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleCustomerGroupRepository : EfRepositoryBase<CartRuleCustomerGroup, uint, BaseDbContext>, ICartRuleCustomerGroupRepository
{
    public CartRuleCustomerGroupRepository(BaseDbContext context) : base(context)
    {
    }
}