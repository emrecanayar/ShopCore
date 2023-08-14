using Core.Application.Responses;

namespace Application.Features.CartRuleCustomers.Commands.Delete;

public class DeletedCartRuleCustomerResponse : IResponse
{
    public uint Id { get; set; }
}