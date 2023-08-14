using Core.Application.Responses;

namespace Application.Features.CartItemInventories.Queries.GetById;

public class GetByIdCartItemInventoryResponse : IResponse
{
    public uint Id { get; set; }
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }
}