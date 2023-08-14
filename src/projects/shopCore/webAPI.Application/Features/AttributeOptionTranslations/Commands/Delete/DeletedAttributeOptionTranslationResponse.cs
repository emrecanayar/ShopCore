using Core.Application.Responses;

namespace Application.Features.AttributeOptionTranslations.Commands.Delete;

public class DeletedAttributeOptionTranslationResponse : IResponse
{
    public uint Id { get; set; }
}