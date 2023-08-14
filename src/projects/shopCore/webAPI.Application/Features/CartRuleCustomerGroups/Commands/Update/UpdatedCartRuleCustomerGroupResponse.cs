using Core.Application.Responses;

namespace Application.Features.CartRuleCustomerGroups.Commands.Update;

public class UpdatedCartRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}