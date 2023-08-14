using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartItemInventory : Entity<uint>
    {
        public uint Qty { get; set; }
        public uint? InventorySourceId { get; set; }
        public uint? CartItemId { get; set; }

        public CartItemInventory()
        {
        }

        public CartItemInventory(uint qty, uint? inventorySourceId, uint? cartItemId)
        {
            Qty = qty;
            InventorySourceId = inventorySourceId;
            CartItemId = cartItemId;
        }
    }

}
