using Core.Application.Responses;

namespace Application.Features.AttributeOptions.Commands.Delete;

public class DeletedAttributeOptionResponse : IResponse
{
    public uint Id { get; set; }
}