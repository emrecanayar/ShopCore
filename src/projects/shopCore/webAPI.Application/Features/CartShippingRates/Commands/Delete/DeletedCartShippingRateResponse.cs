using Core.Application.Responses;

namespace Application.Features.CartShippingRates.Commands.Delete;

public class DeletedCartShippingRateResponse : IResponse
{
    public uint Id { get; set; }
}