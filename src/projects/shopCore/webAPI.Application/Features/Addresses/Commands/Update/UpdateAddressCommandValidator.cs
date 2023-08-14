using FluentValidation;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AddressType).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Gender).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Address1).NotEmpty();
        RuleFor(c => c.Address2).NotEmpty();
        RuleFor(c => c.Postcode).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.VatId).NotEmpty();
        RuleFor(c => c.DefaultAddress).NotEmpty();
        RuleFor(c => c.Additional).NotEmpty();
    }
}