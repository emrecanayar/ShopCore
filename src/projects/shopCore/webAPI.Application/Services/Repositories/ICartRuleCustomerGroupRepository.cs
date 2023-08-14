using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartRuleCustomerGroupRepository : IAsyncRepository<CartRuleCustomerGroup, uint>, IRepository<CartRuleCustomerGroup, uint>
{
}