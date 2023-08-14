using Core.Application.Responses;

namespace Application.Features.CartPayments.Commands.Delete;

public class DeletedCartPaymentResponse : IResponse
{
    public uint Id { get; set; }
}