using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartItemRepository : EfRepositoryBase<CartItem, uint, BaseDbContext>, ICartItemRepository
{
    public CartItemRepository(BaseDbContext context) : base(context)
    {
    }
}