using Core.Application.Responses;

namespace Application.Features.AttributeFamilies.Queries.GetById;

public class GetByIdAttributeFamilyResponse : IResponse
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool? IsUserDefined { get; set; }
}