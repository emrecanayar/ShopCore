using Core.Application.Responses;

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Delete;

public class DeletedCatalogRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
}