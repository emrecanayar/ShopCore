using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AddressConfiguration : BaseConfiguration<Address, uint>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {

        builder.Property(a => a.AddressType).HasColumnName("AddressType");
        builder.Property(a => a.CustomerId).HasColumnName("CustomerId");
        builder.Property(a => a.CartId).HasColumnName("CartId");
        builder.Property(a => a.OrderId).HasColumnName("OrderId");
        builder.Property(a => a.FirstName).HasColumnName("FirstName");
        builder.Property(a => a.LastName).HasColumnName("LastName");
        builder.Property(a => a.Gender).HasColumnName("Gender");
        builder.Property(a => a.CompanyName).HasColumnName("CompanyName");
        builder.Property(a => a.Address1).HasColumnName("Address1");
        builder.Property(a => a.Address2).HasColumnName("Address2");
        builder.Property(a => a.Postcode).HasColumnName("Postcode");
        builder.Property(a => a.City).HasColumnName("City");
        builder.Property(a => a.State).HasColumnName("State");
        builder.Property(a => a.Country).HasColumnName("Country");
        builder.Property(a => a.Email).HasColumnName("Email");
        builder.Property(a => a.Phone).HasColumnName("Phone");
        builder.Property(a => a.VatId).HasColumnName("VatId");
        builder.Property(a => a.DefaultAddress).HasColumnName("DefaultAddress");
        builder.Property(a => a.Additional).HasColumnName("Additional");
        builder.ToTable(TableNameConstants.ADDRESS);

    }
}