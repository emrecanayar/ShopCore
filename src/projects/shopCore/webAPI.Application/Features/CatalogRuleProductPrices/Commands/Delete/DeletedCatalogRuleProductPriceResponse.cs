using Core.Application.Responses;

namespace Application.Features.CatalogRuleProductPrices.Commands.Delete;

public class DeletedCatalogRuleProductPriceResponse : IResponse
{
    public uint Id { get; set; }
}