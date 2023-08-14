using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartItemInventoryRepository : IAsyncRepository<CartItemInventory, uint>, IRepository<CartItemInventory, uint>
{
}