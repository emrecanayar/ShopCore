using Core.Application.Dtos;

namespace Application.Features.CartRuleTranslations.Queries.GetList;

public class GetListCartRuleTranslationListItemDto : IDto
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint CartRuleId { get; set; }
}