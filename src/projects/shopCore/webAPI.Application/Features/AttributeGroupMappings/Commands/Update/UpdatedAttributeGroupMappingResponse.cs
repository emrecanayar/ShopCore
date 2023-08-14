using Core.Application.Responses;

namespace Application.Features.AttributeGroupMappings.Commands.Update;

public class UpdatedAttributeGroupMappingResponse : IResponse
{
    public uint Id { get; set; }
    public uint AttributeId { get; set; }
    public uint AttributeGroupId { get; set; }
    public int? Position { get; set; }
}