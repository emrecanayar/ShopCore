using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartItemInventoryConfiguration : BaseConfiguration<CartItemInventory, uint>
{
    public override void Configure(EntityTypeBuilder<CartItemInventory> builder)
    {

        builder.Property(cii => cii.Qty).HasColumnName("Qty");
        builder.Property(cii => cii.InventorySourceId).HasColumnName("InventorySourceId");
        builder.Property(cii => cii.CartItemId).HasColumnName("CartItemId");
        builder.ToTable(TableNameConstants.CART_ITEM_INVENTORY);

    }
}