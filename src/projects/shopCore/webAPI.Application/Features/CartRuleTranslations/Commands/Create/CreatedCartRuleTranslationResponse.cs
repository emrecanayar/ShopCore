using Core.Application.Responses;

namespace Application.Features.CartRuleTranslations.Commands.Create;

public class CreatedCartRuleTranslationResponse : IResponse
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint CartRuleId { get; set; }
}