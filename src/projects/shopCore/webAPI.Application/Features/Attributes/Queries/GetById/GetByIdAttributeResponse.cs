using Core.Application.Responses;

namespace Application.Features.Attributes.Queries.GetById;

public class GetByIdAttributeResponse : IResponse
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string AdminName { get; set; }
    public string Type { get; set; }
    public string? Validation { get; set; }
    public int? Position { get; set; }
    public bool IsRequired { get; set; }
    public bool IsUnique { get; set; }
    public bool ValuePerLocale { get; set; }
    public bool ValuePerChannel { get; set; }
    public bool IsFilterable { get; set; }
    public bool IsConfigurable { get; set; }
    public bool? IsUserDefined { get; set; }
    public bool IsVisibleOnFront { get; set; }
    public string? SwatchType { get; set; }
    public bool? UseInFlat { get; set; }
    public bool IsComparable { get; set; }
    public bool EnableWysiwyg { get; set; }
}