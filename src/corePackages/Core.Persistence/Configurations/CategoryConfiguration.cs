using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : BaseConfiguration<Category, uint>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.Property(c => c.Position).HasColumnName("Position");
        builder.Property(c => c.Image).HasColumnName("Image");
        builder.Property(c => c.Status).HasColumnName("Status");
        builder.Property(c => c.Lft).HasColumnName("Lft");
        builder.Property(c => c.Rgt).HasColumnName("Rgt");
        builder.Property(c => c.ParentId).HasColumnName("ParentId");
        builder.Property(c => c.DisplayMode).HasColumnName("DisplayMode");
        builder.Property(c => c.CategoryIconPath).HasColumnName("CategoryIconPath");
        builder.Property(c => c.Additional).HasColumnName("Additional");
        builder.ToTable(TableNameConstants.CATEGORY);

    }
}