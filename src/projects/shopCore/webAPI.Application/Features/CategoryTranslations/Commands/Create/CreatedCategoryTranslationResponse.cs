using Core.Application.Responses;

namespace Application.Features.CategoryTranslations.Commands.Create;

public class CreatedCategoryTranslationResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
    public uint CategoryId { get; set; }
    public string Locale { get; set; }
    public uint? LocaleId { get; set; }
    public string UrlPath { get; set; }
}