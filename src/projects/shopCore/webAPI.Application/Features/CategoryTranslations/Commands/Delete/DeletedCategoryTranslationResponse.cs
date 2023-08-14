using Core.Application.Responses;

namespace Application.Features.CategoryTranslations.Commands.Delete;

public class DeletedCategoryTranslationResponse : IResponse
{
    public uint Id { get; set; }
}