using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICatalogRuleChannelRepository : IAsyncRepository<CatalogRuleChannel, uint>, IRepository<CatalogRuleChannel, uint>
{
}