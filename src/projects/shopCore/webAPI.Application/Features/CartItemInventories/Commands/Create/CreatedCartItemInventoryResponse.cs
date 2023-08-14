using Core.Application.Responses;

namespace Application.Features.CartItemInventories.Commands.Create;

public class CreatedCartItemInventoryResponse : IResponse
{
    public uint Id { get; set; }
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }
}