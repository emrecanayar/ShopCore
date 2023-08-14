using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CategoryTranslationRepository : EfRepositoryBase<CategoryTranslation, uint, BaseDbContext>, ICategoryTranslationRepository
{
    public CategoryTranslationRepository(BaseDbContext context) : base(context)
    {
    }
}