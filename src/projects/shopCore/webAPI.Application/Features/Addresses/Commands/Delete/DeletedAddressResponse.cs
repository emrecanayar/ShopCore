using Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Delete;

public class DeletedAddressResponse : IResponse
{
    public uint Id { get; set; }
}