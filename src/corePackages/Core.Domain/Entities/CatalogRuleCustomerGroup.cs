using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CatalogRuleCustomerGroup : Entity<uint>
    {
        public uint CatalogRuleId { get; set; }
        public uint CustomerGroupId { get; set; }

        public CatalogRuleCustomerGroup()
        {
        }

        public CatalogRuleCustomerGroup(uint catalogRuleId, uint customerGroupId)
        {
            CatalogRuleId = catalogRuleId;
            CustomerGroupId = customerGroupId;
        }
    }

}
