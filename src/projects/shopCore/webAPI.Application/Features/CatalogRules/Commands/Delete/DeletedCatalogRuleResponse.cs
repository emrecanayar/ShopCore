using Core.Application.Responses;

namespace Application.Features.CatalogRules.Commands.Delete;

public class DeletedCatalogRuleResponse : IResponse
{
    public uint Id { get; set; }
}