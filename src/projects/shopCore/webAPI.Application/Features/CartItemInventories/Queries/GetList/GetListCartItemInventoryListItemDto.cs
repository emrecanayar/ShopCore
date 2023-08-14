using Core.Application.Dtos;

namespace Application.Features.CartItemInventories.Queries.GetList;

public class GetListCartItemInventoryListItemDto : IDto
{
    public uint Id { get; set; }
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }
}