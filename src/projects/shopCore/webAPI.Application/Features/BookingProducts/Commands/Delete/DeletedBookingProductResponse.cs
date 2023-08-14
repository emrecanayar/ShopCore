using Core.Application.Responses;

namespace Application.Features.BookingProducts.Commands.Delete;

public class DeletedBookingProductResponse : IResponse
{
    public uint Id { get; set; }
}