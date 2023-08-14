using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleCouponUsage : Entity<uint>
    {
        public int TimesUsed { get; set; }
        public uint CartRuleCouponId { get; set; }
        public uint CustomerId { get; set; }

        public CartRuleCouponUsage()
        {
        }

        public CartRuleCouponUsage(int timesUsed, uint cartRuleCouponId, uint customerId)
        {
            TimesUsed = timesUsed;
            CartRuleCouponId = cartRuleCouponId;
            CustomerId = customerId;
        }
    }

}
