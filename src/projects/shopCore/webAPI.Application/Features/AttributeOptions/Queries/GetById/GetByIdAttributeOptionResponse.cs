using Core.Application.Responses;

namespace Application.Features.AttributeOptions.Queries.GetById;

public class GetByIdAttributeOptionResponse : IResponse
{
    public uint Id { get; set; }
    public string? AdminName { get; set; }
    public int? SortOrder { get; set; }
    public uint AttributeId { get; set; }
    public string? SwatchValue { get; set; }
}