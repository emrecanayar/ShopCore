using Core.Application.Responses;

namespace Application.Features.CategoryFilterableAttributes.Queries.GetById;

public class GetByIdCategoryFilterableAttributeResponse : IResponse
{
    public uint Id { get; set; }
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }
}