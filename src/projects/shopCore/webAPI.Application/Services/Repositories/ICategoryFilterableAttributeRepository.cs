using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryFilterableAttributeRepository : IAsyncRepository<CategoryFilterableAttribute, uint>, IRepository<CategoryFilterableAttribute, uint>
{
}