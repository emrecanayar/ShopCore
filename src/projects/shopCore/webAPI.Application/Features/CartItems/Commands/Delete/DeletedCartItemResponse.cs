using Core.Application.Responses;

namespace Application.Features.CartItems.Commands.Delete;

public class DeletedCartItemResponse : IResponse
{
    public uint Id { get; set; }
}