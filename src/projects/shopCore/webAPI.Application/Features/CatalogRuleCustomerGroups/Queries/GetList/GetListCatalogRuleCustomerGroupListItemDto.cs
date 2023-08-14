using Core.Application.Dtos;

namespace Application.Features.CatalogRuleCustomerGroups.Queries.GetList;

public class GetListCatalogRuleCustomerGroupListItemDto : IDto
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}