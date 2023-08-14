using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CategoryFilterableAttribute : Entity<uint>
    {
        public uint CategoryId { get; set; }
        public uint AttributeId { get; set; }

        public CategoryFilterableAttribute()
        {
        }

        public CategoryFilterableAttribute(uint categoryId, uint attributeId)
        {
            CategoryId = categoryId;
            AttributeId = attributeId;
        }
    }

}
