using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleCouponUsageRepository : EfRepositoryBase<CartRuleCouponUsage, uint, BaseDbContext>, ICartRuleCouponUsageRepository
{
    public CartRuleCouponUsageRepository(BaseDbContext context) : base(context)
    {
    }
}