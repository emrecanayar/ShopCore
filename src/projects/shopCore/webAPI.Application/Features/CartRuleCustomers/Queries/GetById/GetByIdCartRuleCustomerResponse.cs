using Core.Application.Responses;

namespace Application.Features.CartRuleCustomers.Queries.GetById;

public class GetByIdCartRuleCustomerResponse : IResponse
{
    public uint Id { get; set; }
    public ulong TimesUsed { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerId { get; set; }
}