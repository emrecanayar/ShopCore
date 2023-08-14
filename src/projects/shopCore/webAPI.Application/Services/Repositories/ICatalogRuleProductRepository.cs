using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICatalogRuleProductRepository : IAsyncRepository<CatalogRuleProduct, uint>, IRepository<CatalogRuleProduct, uint>
{
}