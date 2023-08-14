using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartShippingRateRepository : IAsyncRepository<CartShippingRate, uint>, IRepository<CartShippingRate, uint>
{
}