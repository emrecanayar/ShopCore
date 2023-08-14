using Core.Application.Responses;

namespace Application.Features.CategoryFilterableAttributes.Commands.Create;

public class CreatedCategoryFilterableAttributeResponse : IResponse
{
    public uint Id { get; set; }
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }
}