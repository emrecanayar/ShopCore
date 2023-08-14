using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category, uint>, IRepository<Category, uint>
{
}