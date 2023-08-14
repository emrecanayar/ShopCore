using Core.Application.Responses;

namespace Application.Features.CartRuleCouponUsages.Queries.GetById;

public class GetByIdCartRuleCouponUsageResponse : IResponse
{
    public uint Id { get; set; }
    public int TimesUsed { get; set; }
    public uint CartRuleCouponId { get; set; }
    public uint CustomerId { get; set; }
}