using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartShippingRate : Entity<uint>
    {
        public string Carrier { get; set; } = null!;
        public string CarrierTitle { get; set; } = null!;
        public string Method { get; set; } = null!;
        public string MethodTitle { get; set; } = null!;
        public string? MethodDescription { get; set; }
        public double? Price { get; set; }
        public double? BasePrice { get; set; }
        public uint? CartAddressId { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BaseDiscountAmount { get; set; }
        public bool? IsCalculateTax { get; set; }

        public CartShippingRate()
        {
            DiscountAmount = 0;
            BaseDiscountAmount = 0;
        }

        public CartShippingRate(string carrier, string carrierTitle, string method, string methodTitle)
        {
            Carrier = carrier;
            CarrierTitle = carrierTitle;
            Method = method;
            MethodTitle = methodTitle;
            DiscountAmount = 0;
            BaseDiscountAmount = 0;
        }
    }

}
