using Core.Application.Responses;

namespace Application.Features.CartRuleCustomerGroups.Commands.Create;

public class CreatedCartRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }
}