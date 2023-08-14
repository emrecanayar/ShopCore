using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAttributeGroupRepository : IAsyncRepository<AttributeGroup, uint>, IRepository<AttributeGroup, uint>
{
}