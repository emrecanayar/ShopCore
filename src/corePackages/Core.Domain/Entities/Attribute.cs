using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Attribute : Entity<uint>
    {
        public string Code { get; set; } = null!;
        public string AdminName { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Validation { get; set; }
        public int? Position { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
        public bool ValuePerLocale { get; set; }
        public bool ValuePerChannel { get; set; }
        public bool IsFilterable { get; set; }
        public bool IsConfigurable { get; set; }
        public bool? IsUserDefined { get; set; }
        public bool IsVisibleOnFront { get; set; }
        public string? SwatchType { get; set; }
        public bool? UseInFlat { get; set; }
        public bool IsComparable { get; set; }
        public bool EnableWysiwyg { get; set; }

        public Attribute()
        {
            Code = string.Empty;
            AdminName = string.Empty;
            Type = string.Empty;
            IsRequired = false;
            IsUnique = false;
            ValuePerLocale = false;
            ValuePerChannel = false;
            IsFilterable = false;
            IsConfigurable = false;
            IsVisibleOnFront = false;
            IsComparable = false;
            EnableWysiwyg = false;
        }

        public Attribute(string code, string adminName, string type)
        {
            Code = code;
            AdminName = adminName;
            Type = type;
            IsRequired = false;
            IsUnique = false;
            ValuePerLocale = false;
            ValuePerChannel = false;
            IsFilterable = false;
            IsConfigurable = false;
            IsVisibleOnFront = false;
            IsComparable = false;
            EnableWysiwyg = false;
        }
    }

}
