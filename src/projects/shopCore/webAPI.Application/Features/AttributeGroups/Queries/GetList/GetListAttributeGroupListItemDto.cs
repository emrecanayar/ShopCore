using Core.Application.Dtos;

namespace Application.Features.AttributeGroups.Queries.GetList;

public class GetListAttributeGroupListItemDto : IDto
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public bool? IsUserDefined { get; set; }
    public uint AttributeFamilyId { get; set; }
}