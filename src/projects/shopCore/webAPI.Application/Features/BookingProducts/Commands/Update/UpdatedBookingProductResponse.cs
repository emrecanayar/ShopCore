using Core.Application.Responses;

namespace Application.Features.BookingProducts.Commands.Update;

public class UpdatedBookingProductResponse : IResponse
{
    public uint Id { get; set; }
    public string Type { get; set; }
    public int? Qty { get; set; }
    public string? Location { get; set; }
    public bool ShowLocation { get; set; }
    public bool? AvailableEveryWeek { get; set; }
    public DateTime? AvailableFrom { get; set; }
    public DateTime? AvailableTo { get; set; }
    public uint ProductId { get; set; }
}