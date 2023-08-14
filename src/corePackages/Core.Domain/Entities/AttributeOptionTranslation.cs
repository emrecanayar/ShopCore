using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AttributeOptionTranslation : Entity<uint>
    {
        public string Locale { get; set; } = null!;
        public string? Label { get; set; }
        public uint AttributeOptionId { get; set; }

        public AttributeOptionTranslation()
        {
            Locale = string.Empty;
        }

        public AttributeOptionTranslation(string locale, string? label, uint attributeOptionId)
        {
            Locale = locale;
            Label = label;
            AttributeOptionId = attributeOptionId;
        }
    }

}
