using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleCouponRepository : EfRepositoryBase<CartRuleCoupon, uint, BaseDbContext>, ICartRuleCouponRepository
{
    public CartRuleCouponRepository(BaseDbContext context) : base(context)
    {
    }
}