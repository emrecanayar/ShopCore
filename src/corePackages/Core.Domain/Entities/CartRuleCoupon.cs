using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleCoupon : Entity<uint>
    {
        public string? Code { get; set; }
        public uint UsageLimit { get; set; }
        public uint UsagePerCustomer { get; set; }
        public uint TimesUsed { get; set; }
        public uint Type { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public uint CartRuleId { get; set; }

        public CartRuleCoupon()
        {
            UsageLimit = 0;
            UsagePerCustomer = 0;
            TimesUsed = 0;
            IsPrimary = false;
        }

        public CartRuleCoupon(uint cartRuleId)
        {
            UsageLimit = 0;
            UsagePerCustomer = 0;
            TimesUsed = 0;
            IsPrimary = false;
            CartRuleId = cartRuleId;
        }
    }

}
