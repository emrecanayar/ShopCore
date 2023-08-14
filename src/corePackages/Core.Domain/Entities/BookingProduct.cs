using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class BookingProduct : Entity<uint>
    {
        public string Type { get; set; } = null!;
        public int? Qty { get; set; }
        public string? Location { get; set; }
        public bool ShowLocation { get; set; }
        public bool? AvailableEveryWeek { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public uint ProductId { get; set; }

        public BookingProduct()
        {
            Type = string.Empty;
            ShowLocation = false;
        }

        public BookingProduct(string type, uint productId)
        {
            Type = type;
            ProductId = productId;
            ShowLocation = false;
        }
    }

}
