using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartItem : Entity<uint>
    {
        public uint Quantity { get; set; }
        public string? Sku { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? CouponCode { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal BaseTotalWeight { get; set; }
        public decimal Price { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Total { get; set; }
        public decimal BaseTotal { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? BaseTaxAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BaseDiscountAmount { get; set; }
        public string? Additional { get; set; }
        public uint? ParentId { get; set; }
        public uint ProductId { get; set; }
        public uint CartId { get; set; }
        public uint? TaxCategoryId { get; set; }
        public decimal? CustomPrice { get; set; }
        public string? AppliedCartRuleIds { get; set; }

        public CartItem()
        {
            DiscountPercent = 0;
            DiscountAmount = 0;
            BaseDiscountAmount = 0;
        }

        public CartItem(uint productId, uint cartId)
        {
            ProductId = productId;
            CartId = cartId;
            DiscountPercent = 0;
            DiscountAmount = 0;
            BaseDiscountAmount = 0;
        }
    }

}
