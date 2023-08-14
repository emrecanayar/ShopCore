using Core.Application.Responses;

namespace Application.Features.AttributeGroups.Commands.Update;

public class UpdatedAttributeGroupResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public bool? IsUserDefined { get; set; }
    public uint AttributeFamilyId { get; set; }
}