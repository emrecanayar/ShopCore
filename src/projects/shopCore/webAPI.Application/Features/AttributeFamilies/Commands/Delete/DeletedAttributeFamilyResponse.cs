using Core.Application.Responses;

namespace Application.Features.AttributeFamilies.Commands.Delete;

public class DeletedAttributeFamilyResponse : IResponse
{
    public uint Id { get; set; }
}