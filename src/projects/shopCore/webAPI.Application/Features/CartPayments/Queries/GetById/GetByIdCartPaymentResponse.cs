using Core.Application.Responses;

namespace Application.Features.CartPayments.Queries.GetById;

public class GetByIdCartPaymentResponse : IResponse
{
    public uint Id { get; set; }
    public string Method { get; set; }
    public string? MethodTitle { get; set; }
    public uint? CartId { get; set; }
}