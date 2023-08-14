using Core.Application.Responses;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Create;

public class CreatedCatalogRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}