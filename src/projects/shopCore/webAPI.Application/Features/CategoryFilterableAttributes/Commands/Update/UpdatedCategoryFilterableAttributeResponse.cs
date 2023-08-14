using Core.Application.Responses;

namespace Application.Features.CategoryFilterableAttributes.Commands.Update;

public class UpdatedCategoryFilterableAttributeResponse : IResponse
{
    public uint Id { get; set; }
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }
}