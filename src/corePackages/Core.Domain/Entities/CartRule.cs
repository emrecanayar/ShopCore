using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRule : Entity<uint>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartsFrom { get; set; }
        public DateTime? EndsTill { get; set; }
        public bool Status { get; set; }
        public int CouponType { get; set; }
        public bool UseAutoGeneration { get; set; }
        public int UsagePerCustomer { get; set; }
        public int UsesPerCoupon { get; set; }
        public uint TimesUsed { get; set; }
        public bool? ConditionType { get; set; }
        public string? Conditions { get; set; }
        public bool EndOtherRules { get; set; }
        public bool UsesAttributeConditions { get; set; }
        public string? ActionType { get; set; }
        public decimal DiscountAmount { get; set; }
        public int DiscountQuantity { get; set; }
        public string DiscountStep { get; set; } = null!;
        public bool ApplyToShipping { get; set; }
        public bool FreeShipping { get; set; }
        public uint SortOrder { get; set; }

        public CartRule()
        {
            Status = false;
            UseAutoGeneration = false;
            UsagePerCustomer = 0;
            UsesPerCoupon = 0;
            TimesUsed = 0;
            EndOtherRules = false;
            UsesAttributeConditions = false;
            ApplyToShipping = false;
            FreeShipping = false;
        }
    }

}
