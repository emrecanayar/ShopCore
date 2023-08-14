using Core.Application.Dtos;

namespace Application.Features.AttributeFamilies.Queries.GetList;

public class GetListAttributeFamilyListItemDto : IDto
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool? IsUserDefined { get; set; }
}