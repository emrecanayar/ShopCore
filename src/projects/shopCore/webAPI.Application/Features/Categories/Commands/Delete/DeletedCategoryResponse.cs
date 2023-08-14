using Core.Application.Responses;

namespace Application.Features.Categories.Commands.Delete;

public class DeletedCategoryResponse : IResponse
{
    public uint Id { get; set; }
}