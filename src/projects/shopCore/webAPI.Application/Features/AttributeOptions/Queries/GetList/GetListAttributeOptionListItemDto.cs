using Core.Application.Dtos;

namespace Application.Features.AttributeOptions.Queries.GetList;

public class GetListAttributeOptionListItemDto : IDto
{
    public uint Id { get; set; }
    public string? AdminName { get; set; }
    public int? SortOrder { get; set; }
    public uint AttributeId { get; set; }
    public string? SwatchValue { get; set; }
}