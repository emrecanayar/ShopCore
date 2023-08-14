using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartRuleRepository : IAsyncRepository<CartRule, uint>, IRepository<CartRule, uint>
{
}