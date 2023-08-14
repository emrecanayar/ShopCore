using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartRepository : IAsyncRepository<Cart, uint>, IRepository<Cart, uint>
{
}