using Core.Application.Responses;

namespace Application.Features.CartRuleCustomerGroups.Queries.GetById;

public class GetByIdCartRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}