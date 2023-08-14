using Core.Application.Responses;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryResponse : IResponse
{
    public uint Id { get; set; }
    public int Position { get; set; }
    public string? Image { get; set; }
    public bool Status { get; set; }
    public uint Lft { get; set; }
    public uint Rgt { get; set; }
    public uint? ParentId { get; set; }
    public string? DisplayMode { get; set; }
    public string? CategoryIconPath { get; set; }
    public string? Additional { get; set; }
}