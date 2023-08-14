using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CatalogRuleChannelConfiguration : BaseConfiguration<CatalogRuleChannel, uint>
{
    public override void Configure(EntityTypeBuilder<CatalogRuleChannel> builder)
    {

        builder.Property(crc => crc.CatalogRuleId).HasColumnName("CatalogRuleId");
        builder.Property(crc => crc.ChannelId).HasColumnName("ChannelId");
        builder.Property(TableNameConstants.CATALOG_RULE_CHANNEL);

    }
}