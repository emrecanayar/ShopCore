using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICatalogRuleRepository : IAsyncRepository<CatalogRule, uint>, IRepository<CatalogRule, uint>
{
}