using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryTranslationRepository : IAsyncRepository<CategoryTranslation, uint>, IRepository<CategoryTranslation, uint>
{
}