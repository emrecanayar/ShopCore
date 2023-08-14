using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartItemInventoryRepository : EfRepositoryBase<CartItemInventory, uint, BaseDbContext>, ICartItemInventoryRepository
{
    public CartItemInventoryRepository(BaseDbContext context) : base(context)
    {
    }
}