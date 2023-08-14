using Core.Application.Responses;

namespace Application.Features.AttributeOptionTranslations.Commands.Create;

public class CreatedAttributeOptionTranslationResponse : IResponse
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint AttributeOptionId { get; set; }
}