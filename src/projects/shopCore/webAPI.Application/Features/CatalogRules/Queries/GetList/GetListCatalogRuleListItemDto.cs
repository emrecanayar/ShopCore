using Core.Application.Dtos;

namespace Application.Features.CatalogRules.Queries.GetList;

public class GetListCatalogRuleListItemDto : IDto
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool Status { get; set; }
    public bool? ConditionType { get; set; }
    public string? Conditions { get; set; }
    public bool EndOtherRules { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public uint SortOrder { get; set; }
}