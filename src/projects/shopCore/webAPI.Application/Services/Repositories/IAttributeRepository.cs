using Core.Persistence.Repositories;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Services.Repositories;

public interface IAttributeRepository : IAsyncRepository<Attribute, uint>, IRepository<Attribute, uint>
{
}