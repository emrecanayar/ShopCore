using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Cart : Entity<uint>
    {
        public string? CustomerEmail { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? ShippingMethod { get; set; }
        public string? CouponCode { get; set; }
        public bool IsGift { get; set; }
        public int? ItemsCount { get; set; }
        public decimal? ItemsQty { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? GlobalCurrencyCode { get; set; }
        public string? BaseCurrencyCode { get; set; }
        public string? ChannelCurrencyCode { get; set; }
        public string? CartCurrencyCode { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? BaseGrandTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? BaseSubTotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? BaseTaxTotal { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? BaseDiscountAmount { get; set; }
        public string? CheckoutMethod { get; set; }
        public bool? IsGuest { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ConversionTime { get; set; }
        public uint? CustomerId { get; set; }
        public uint ChannelId { get; set; }
        public string? AppliedCartRuleIds { get; set; }

        public Cart()
        {
            IsGift = false;
        }

        public Cart(uint channelId)
        {
            IsGift = false;
            ChannelId = channelId;
        }
    }

}
