using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRepository : EfRepositoryBase<Cart, uint, BaseDbContext>, ICartRepository
{
    public CartRepository(BaseDbContext context) : base(context)
    {
    }
}