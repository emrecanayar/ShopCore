using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartRuleTranslationRepository : IAsyncRepository<CartRuleTranslation, uint>, IRepository<CartRuleTranslation, uint>
{
}