using Core.Application.Dtos;

namespace Application.Features.CategoryFilterableAttributes.Queries.GetList;

public class GetListCategoryFilterableAttributeListItemDto : IDto
{
    public uint Id { get; set; }
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }
}