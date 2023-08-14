using Core.Application.Responses;

namespace Application.Features.CartShippingRates.Commands.Update;

public class UpdatedCartShippingRateResponse : IResponse
{
    public uint Id { get; set; }
    public string Carrier { get; set; }
    public string CarrierTitle { get; set; }
    public string Method { get; set; }
    public string MethodTitle { get; set; }
    public string? MethodDescription { get; set; }
    public double? Price { get; set; }
    public double? BasePrice { get; set; }
    public uint? CartAddressId { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal BaseDiscountAmount { get; set; }
    public bool? IsCalculateTax { get; set; }
}