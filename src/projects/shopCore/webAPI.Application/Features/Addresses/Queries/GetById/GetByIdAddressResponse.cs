using Core.Application.Responses;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressResponse : IResponse
{
    public uint Id { get; set; }
    public string AddressType { get; set; }
    public uint? CustomerId { get; set; }
    public uint? CartId { get; set; }
    public uint? OrderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public string? CompanyName { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Postcode { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? VatId { get; set; }
    public bool DefaultAddress { get; set; }
    public string? Additional { get; set; }
}