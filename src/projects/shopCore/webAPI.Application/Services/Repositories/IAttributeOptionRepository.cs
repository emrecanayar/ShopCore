using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAttributeOptionRepository : IAsyncRepository<AttributeOption, uint>, IRepository<AttributeOption, uint>
{
}