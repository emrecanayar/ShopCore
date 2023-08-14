using Core.Application.Dtos;

namespace Application.Features.AttributeGroupMappings.Queries.GetList;

public class GetListAttributeGroupMappingListItemDto : IDto
{
    public uint Id { get; set; }
    public uint AttributeId { get; set; }
    public uint AttributeGroupId { get; set; }
    public int? Position { get; set; }
}