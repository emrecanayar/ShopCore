using Core.Application.Responses;

namespace Application.Features.Carts.Commands.Delete;

public class DeletedCartResponse : IResponse
{
    public uint Id { get; set; }
}