using Core.Application.Responses;

namespace Application.Features.CartPayments.Commands.Create;

public class CreatedCartPaymentResponse : IResponse
{
    public uint Id { get; set; }
    public string Method { get; set; }
    public string? MethodTitle { get; set; }
    public uint? CartId { get; set; }
}