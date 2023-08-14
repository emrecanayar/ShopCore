using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CartRuleTranslation : Entity<uint>
    {
        public string Locale { get; set; } = null!;
        public string? Label { get; set; }
        public uint CartRuleId { get; set; }

        public CartRuleTranslation()
        {
            Locale = string.Empty;
        }

        public CartRuleTranslation(string locale, uint cartRuleId)
        {
            Locale = locale;
            CartRuleId = cartRuleId;
        }
    }

}
