using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICatalogRuleCustomerGroupRepository : IAsyncRepository<CatalogRuleCustomerGroup, uint>, IRepository<CatalogRuleCustomerGroup, uint>
{
}