using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleCustomerGroup : Entity<uint>
    {
        public uint CartRuleId { get; set; }
        public uint CustomerGroupId { get; set; }

        public CartRuleCustomerGroup()
        {
        }

        public CartRuleCustomerGroup(uint cartRuleId, uint customerGroupId)
        {
            CartRuleId = cartRuleId;
            CustomerGroupId = customerGroupId;
        }
    }

}
