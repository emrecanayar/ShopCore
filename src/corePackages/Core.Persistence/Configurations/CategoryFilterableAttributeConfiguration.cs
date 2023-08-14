using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CategoryFilterableAttributeConfiguration : BaseConfiguration<CategoryFilterableAttribute, uint>
{
    public override void Configure(EntityTypeBuilder<CategoryFilterableAttribute> builder)
    {

        builder.Property(cfa => cfa.CategoryId).HasColumnName("CategoryId");
        builder.Property(cfa => cfa.AttributeId).HasColumnName("AttributeId");
        builder.ToTable(TableNameConstants.CATEGORY_FILTERABLE_ATTRIBUTES);

    }
}