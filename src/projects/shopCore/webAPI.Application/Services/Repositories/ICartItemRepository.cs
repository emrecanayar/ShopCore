using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartItemRepository : IAsyncRepository<CartItem, uint>, IRepository<CartItem, uint>
{
}