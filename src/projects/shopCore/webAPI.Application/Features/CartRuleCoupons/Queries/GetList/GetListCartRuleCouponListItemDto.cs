using Core.Application.Dtos;

namespace Application.Features.CartRuleCoupons.Queries.GetList;

public class GetListCartRuleCouponListItemDto : IDto
{
    public uint Id { get; set; }
    public string? Code { get; set; }
    public uint UsageLimit { get; set; }
    public uint UsagePerCustomer { get; set; }
    public uint TimesUsed { get; set; }
    public uint Type { get; set; }
    public bool IsPrimary { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public uint CartRuleId { get; set; }
}