using Core.Application.Responses;

namespace Application.Features.AttributeGroupMappings.Commands.Delete;

public class DeletedAttributeGroupMappingResponse : IResponse
{
    public uint Id { get; set; }
}