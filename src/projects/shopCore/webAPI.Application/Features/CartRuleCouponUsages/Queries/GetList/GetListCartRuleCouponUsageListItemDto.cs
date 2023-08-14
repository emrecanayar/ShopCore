using Core.Application.Dtos;

namespace Application.Features.CartRuleCouponUsages.Queries.GetList;

public class GetListCartRuleCouponUsageListItemDto : IDto
{
    public uint Id { get; set; }
    public int TimesUsed { get; set; }
    public uint CartRuleCouponId { get; set; }
    public uint CustomerId { get; set; }
}