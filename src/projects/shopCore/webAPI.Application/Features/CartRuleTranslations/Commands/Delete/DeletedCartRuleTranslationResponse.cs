using Core.Application.Responses;

namespace Application.Features.CartRuleTranslations.Commands.Delete;

public class DeletedCartRuleTranslationResponse : IResponse
{
    public uint Id { get; set; }
}