using Core.Application.Responses;

namespace Application.Features.AttributeGroups.Queries.GetById;

public class GetByIdAttributeGroupResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public bool? IsUserDefined { get; set; }
    public uint AttributeFamilyId { get; set; }
}