using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartPayment : Entity<uint>
    {
        public string Method { get; set; } = null!;
        public string? MethodTitle { get; set; }
        public uint? CartId { get; set; }

        public CartPayment()
        {
            Method = string.Empty;
        }

        public CartPayment(string method)
        {
            Method = method;
        }
    }
}
