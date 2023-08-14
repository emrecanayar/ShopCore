using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AttributeGroup : Entity<uint>
    {
        public string Name { get; set; } = null!;
        public int Position { get; set; }
        public bool? IsUserDefined { get; set; }
        public uint AttributeFamilyId { get; set; }

        public AttributeGroup()
        {
            Name = string.Empty;
            Position = 0;
        }

        public AttributeGroup(string name, int position, uint attributeFamilyId)
        {
            Name = name;
            Position = position;
            AttributeFamilyId = attributeFamilyId;
        }
    }

}
