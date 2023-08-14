using Core.Application.Responses;

namespace Application.Features.CartRuleCouponUsages.Commands.Update;

public class UpdatedCartRuleCouponUsageResponse : IResponse
{
    public uint Id { get; set; }
    public int TimesUsed { get; set; }
    public uint CartRuleCouponId { get; set; }
    public uint CustomerId { get; set; }
}