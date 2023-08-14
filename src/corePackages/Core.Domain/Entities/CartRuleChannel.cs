using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleChannel : Entity<uint>
    {
        public uint CartRuleId { get; set; }
        public uint ChannelId { get; set; }

        public CartRuleChannel()
        {
        }

        public CartRuleChannel(uint cartRuleId, uint channelId)
        {
            CartRuleId = cartRuleId;
            ChannelId = channelId;
        }
    }

}
