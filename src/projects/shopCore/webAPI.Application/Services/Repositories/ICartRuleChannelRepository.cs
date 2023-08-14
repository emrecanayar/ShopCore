using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartRuleChannelRepository : IAsyncRepository<CartRuleChannel, uint>, IRepository<CartRuleChannel, uint>
{
}