using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CatalogRuleChannel : Entity<uint>
    {
        public uint CatalogRuleId { get; set; }
        public uint ChannelId { get; set; }

        public CatalogRuleChannel()
        {
        }

        public CatalogRuleChannel(uint catalogRuleId, uint channelId)
        {
            CatalogRuleId = catalogRuleId;
            ChannelId = channelId;
        }
    }

}
