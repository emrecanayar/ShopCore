using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CatalogRuleProductPrice : Entity<uint>
    {
        public decimal Price { get; set; }
        public DateTime RuleDate { get; set; }
        public DateTime? StartsFrom { get; set; }
        public DateTime? EndsTill { get; set; }
        public uint ProductId { get; set; }
        public uint CustomerGroupId { get; set; }
        public uint CatalogRuleId { get; set; }
        public uint ChannelId { get; set; }

        public CatalogRuleProductPrice()
        {
        }

        public CatalogRuleProductPrice(decimal price, DateTime ruleDate, uint productId, uint catalogRuleId)
        {
            Price = price;
            RuleDate = ruleDate;
            ProductId = productId;
            CatalogRuleId = catalogRuleId;
        }
    }

}
