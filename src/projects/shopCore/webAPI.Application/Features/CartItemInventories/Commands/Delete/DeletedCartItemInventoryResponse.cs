using Core.Application.Responses;

namespace Application.Features.CartItemInventories.Commands.Delete;

public class DeletedCartItemInventoryResponse : IResponse
{
    public uint Id { get; set; }
}