using Core.Application.Responses;

namespace Application.Features.CartRuleCouponUsages.Commands.Delete;

public class DeletedCartRuleCouponUsageResponse : IResponse
{
    public uint Id { get; set; }
}