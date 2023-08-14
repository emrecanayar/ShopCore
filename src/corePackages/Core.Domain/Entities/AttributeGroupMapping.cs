using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AttributeGroupMapping : Entity<uint>
    {
        public uint AttributeId { get; set; }
        public uint AttributeGroupId { get; set; }
        public int? Position { get; set; }

        public AttributeGroupMapping()
        {
        }

        public AttributeGroupMapping(uint attributeId, uint attributeGroupId, int? position)
        {
            AttributeId = attributeId;
            AttributeGroupId = attributeGroupId;
            Position = position;
        }
    }

}
