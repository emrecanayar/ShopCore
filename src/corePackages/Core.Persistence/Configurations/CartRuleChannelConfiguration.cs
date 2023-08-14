using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CartRuleChannelConfiguration : BaseConfiguration<CartRuleChannel, uint>
{
    public override void Configure(EntityTypeBuilder<CartRuleChannel> builder)
    {

        builder.Property(crc => crc.CartRuleId).HasColumnName("CartRuleId");
        builder.Property(crc => crc.ChannelId).HasColumnName("ChannelId");
        builder.ToTable(TableNameConstants.CART_RULE_CHANNEL);

    }
}