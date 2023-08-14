using Core.Application.Responses;

namespace Application.Features.CartRuleCustomerGroups.Commands.Delete;

public class DeletedCartRuleCustomerGroupResponse : IResponse
{
    public uint Id { get; set; }
}