using Core.Application.Dtos;

namespace Application.Features.CartRuleCustomers.Queries.GetList;

public class GetListCartRuleCustomerListItemDto : IDto
{
    public uint Id { get; set; }
    public ulong TimesUsed { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerId { get; set; }
}