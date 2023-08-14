using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CategoryFilterableAttributeRepository : EfRepositoryBase<CategoryFilterableAttribute, uint, BaseDbContext>, ICategoryFilterableAttributeRepository
{
    public CategoryFilterableAttributeRepository(BaseDbContext context) : base(context)
    {
    }
}