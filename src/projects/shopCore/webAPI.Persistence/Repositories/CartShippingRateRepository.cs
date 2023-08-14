using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartShippingRateRepository : EfRepositoryBase<CartShippingRate, uint, BaseDbContext>, ICartShippingRateRepository
{
    public CartShippingRateRepository(BaseDbContext context) : base(context)
    {
    }
}