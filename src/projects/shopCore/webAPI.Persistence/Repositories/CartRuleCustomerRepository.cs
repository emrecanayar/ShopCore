using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleCustomerRepository : EfRepositoryBase<CartRuleCustomer, uint, BaseDbContext>, ICartRuleCustomerRepository
{
    public CartRuleCustomerRepository(BaseDbContext context) : base(context)
    {
    }
}