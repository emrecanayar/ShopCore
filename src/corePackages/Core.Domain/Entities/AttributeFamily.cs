using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AttributeFamily : Entity<uint>
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public bool? IsUserDefined { get; set; }

        public AttributeFamily()
        {
            Code = string.Empty;
            Name = string.Empty;
            Status = false;
        }

        public AttributeFamily(string code, string name, bool status)
        {
            Code = code;
            Name = name;
            Status = status;
        }
    }

}
