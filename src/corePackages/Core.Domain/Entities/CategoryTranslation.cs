using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CategoryTranslation : Entity<uint>
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public uint CategoryId { get; set; }
        public string Locale { get; set; } = null!;
        public uint? LocaleId { get; set; }
        public string UrlPath { get; set; } = null!;

        public CategoryTranslation()
        {
            Name = string.Empty;
            Slug = string.Empty;
            Locale = string.Empty;
            UrlPath = string.Empty;
        }

        public CategoryTranslation(string name, string slug, string locale, string urlPath)
        {
            Name = name;
            Slug = slug;
            Locale = locale;
            UrlPath = urlPath;
        }
    }

}
