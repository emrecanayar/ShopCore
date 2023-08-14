using Core.Application.Responses;

namespace Application.Features.CartItemInventories.Commands.Update;

public class UpdatedCartItemInventoryResponse : IResponse
{
    public uint Id { get; set; }
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }
}