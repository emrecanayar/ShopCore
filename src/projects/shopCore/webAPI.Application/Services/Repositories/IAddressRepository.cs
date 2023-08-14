using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAddressRepository : IAsyncRepository<Address, uint>, IRepository<Address, uint>
{
}