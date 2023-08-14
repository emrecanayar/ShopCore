using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleCustomer : Entity<uint>
    {
        public ulong TimesUsed { get; set; }
        public uint CartRuleId { get; set; }
        public uint CustomerId { get; set; }

        public CartRuleCustomer()
        {
            TimesUsed = 0;
        }

        public CartRuleCustomer(uint cartRuleId, uint customerId)
        {
            TimesUsed = 0;
            CartRuleId = cartRuleId;
            CustomerId = customerId;
        }
    }

}
