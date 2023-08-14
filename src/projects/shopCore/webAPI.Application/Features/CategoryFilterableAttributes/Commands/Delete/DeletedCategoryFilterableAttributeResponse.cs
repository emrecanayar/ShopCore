using Core.Application.Responses;

namespace Application.Features.CategoryFilterableAttributes.Commands.Delete;

public class DeletedCategoryFilterableAttributeResponse : IResponse
{
    public uint Id { get; set; }
}