using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CatalogRuleProduct : Entity<uint>
    {
        public DateTime? StartsFrom { get; set; }
        public DateTime? EndsTill { get; set; }
        public bool EndOtherRules { get; set; }
        public string? ActionType { get; set; }
        public decimal DiscountAmount { get; set; }
        public uint SortOrder { get; set; }
        public uint ProductId { get; set; }
        public uint CustomerGroupId { get; set; }
        public uint CatalogRuleId { get; set; }
        public uint ChannelId { get; set; }

        public CatalogRuleProduct()
        {
            EndOtherRules = false;
        }

        public CatalogRuleProduct(uint productId, uint catalogRuleId)
        {
            ProductId = productId;
            CatalogRuleId = catalogRuleId;
            EndOtherRules = false;
        }
    }

}
