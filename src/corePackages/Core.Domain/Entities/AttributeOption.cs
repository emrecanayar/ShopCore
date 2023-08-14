using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AttributeOption : Entity<uint>
    {
        public string? AdminName { get; set; }
        public int? SortOrder { get; set; }
        public uint AttributeId { get; set; }
        public string? SwatchValue { get; set; }

        public AttributeOption()
        {
        }

        public AttributeOption(string adminName, int? sortOrder, uint attributeId, string? swatchValue)
        {
            AdminName = adminName;
            SortOrder = sortOrder;
            AttributeId = attributeId;
            SwatchValue = swatchValue;
        }
    }

}
