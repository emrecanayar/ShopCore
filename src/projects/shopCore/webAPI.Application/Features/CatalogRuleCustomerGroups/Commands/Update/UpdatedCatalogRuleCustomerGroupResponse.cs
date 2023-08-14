using Core.Application.Responses;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Update;

public class UpdatedCatalogRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}