using Core.Application.Dtos;

namespace Application.Features.CartRuleCustomerGroups.Queries.GetList;

public class GetListCartRuleCustomerGroupListItemDto : IDto
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}