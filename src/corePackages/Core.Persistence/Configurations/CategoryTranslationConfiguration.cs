using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CategoryTranslationConfiguration : BaseConfiguration<CategoryTranslation, uint>
{
    public override void Configure(EntityTypeBuilder<CategoryTranslation> builder)
    {

        builder.Property(ct => ct.Name).HasColumnName("Name");
        builder.Property(ct => ct.Slug).HasColumnName("Slug");
        builder.Property(ct => ct.Description).HasColumnName("Description");
        builder.Property(ct => ct.MetaTitle).HasColumnName("MetaTitle");
        builder.Property(ct => ct.MetaDescription).HasColumnName("MetaDescription");
        builder.Property(ct => ct.MetaKeywords).HasColumnName("MetaKeywords");
        builder.Property(ct => ct.CategoryId).HasColumnName("CategoryId");
        builder.Property(ct => ct.Locale).HasColumnName("Locale");
        builder.Property(ct => ct.LocaleId).HasColumnName("LocaleId");
        builder.Property(ct => ct.UrlPath).HasColumnName("UrlPath");
        builder.ToTable(TableNameConstants.CATEGORY_TRANSLATION);

    }
}