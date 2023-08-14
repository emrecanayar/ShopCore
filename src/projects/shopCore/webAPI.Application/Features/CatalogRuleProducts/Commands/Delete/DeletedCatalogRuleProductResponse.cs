using Core.Application.Responses;

namespace Application.Features.CatalogRuleProducts.Commands.Delete;

public class DeletedCatalogRuleProductResponse : IResponse
{
    public uint Id { get; set; }
}