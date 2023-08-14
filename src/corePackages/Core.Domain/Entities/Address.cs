using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Address : Entity<uint>
    {
        public string AddressType { get; set; } = null!;
        public uint? CustomerId { get; set; }
        public uint? CartId { get; set; }
        public uint? OrderId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Gender { get; set; }
        public string? CompanyName { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Postcode { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? VatId { get; set; }
        public bool DefaultAddress { get; set; }
        public string? Additional { get; set; }

        public Address()
        {
            AddressType = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address1 = string.Empty;
            City = string.Empty;
            DefaultAddress = false;
        }

        public Address(
            string addressType,
            string firstName,
            string lastName,
            string address1,
            string city,
            bool defaultAddress)
        {
            AddressType = addressType;
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            City = city;
            DefaultAddress = defaultAddress;
        }
    }

}
