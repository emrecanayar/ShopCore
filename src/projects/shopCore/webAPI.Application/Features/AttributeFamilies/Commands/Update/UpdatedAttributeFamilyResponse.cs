using Core.Application.Responses;

namespace Application.Features.AttributeFamilies.Commands.Update;

public class UpdatedAttributeFamilyResponse : IResponse
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool? IsUserDefined { get; set; }
}