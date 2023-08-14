using Core.Application.Responses;

namespace Application.Features.CartRuleCoupons.Commands.Delete;

public class DeletedCartRuleCouponResponse : IResponse
{
    public uint Id { get; set; }
}