using Core.Application.Responses;

namespace Application.Features.CatalogRuleCustomerGroups.Queries.GetById;

public class GetByIdCatalogRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}