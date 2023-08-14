using Core.Application.Responses;

namespace Application.Features.Attributes.Commands.Delete;

public class DeletedAttributeResponse : IResponse
{
    public uint Id { get; set; }
}