using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Category : Entity<uint>
    {
        public int Position { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }
        public uint Lft { get; set; }
        public uint Rgt { get; set; }
        public uint? ParentId { get; set; }
        public string? DisplayMode { get; set; }
        public string? CategoryIconPath { get; set; }
        public string? Additional { get; set; }

        public Category()
        {
            Status = false;
        }

        public Category(string displayMode)
        {
            DisplayMode = displayMode;
            Status = false;
        }
    }

}
