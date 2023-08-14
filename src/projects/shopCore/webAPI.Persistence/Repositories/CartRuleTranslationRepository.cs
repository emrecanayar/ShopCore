using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartRuleTranslationRepository : EfRepositoryBase<CartRuleTranslation, uint, BaseDbContext>, ICartRuleTranslationRepository
{
    public CartRuleTranslationRepository(BaseDbContext context) : base(context)
    {
    }
}