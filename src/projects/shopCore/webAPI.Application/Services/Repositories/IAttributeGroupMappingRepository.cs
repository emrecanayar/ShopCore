using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAttributeGroupMappingRepository : IAsyncRepository<AttributeGroupMapping, uint>, IRepository<AttributeGroupMapping, uint>
{
}