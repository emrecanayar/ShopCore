using Core.Application.Dtos;

namespace Application.Features.AttributeOptionTranslations.Queries.GetList;

public class GetListAttributeOptionTranslationListItemDto : IDto
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint AttributeOptionId { get; set; }
}