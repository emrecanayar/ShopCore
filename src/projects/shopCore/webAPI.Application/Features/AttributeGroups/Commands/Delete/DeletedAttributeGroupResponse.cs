using Core.Application.Responses;

namespace Application.Features.AttributeGroups.Commands.Delete;

public class DeletedAttributeGroupResponse : IResponse
{
    public uint Id { get; set; }
}