using Core.Application.Responses;

namespace Application.Features.CatalogRuleProductPrices.Commands.Create;

public class CreatedCatalogRuleProductPriceResponse : IResponse
{
    public uint Id { get; set; }
    public decimal Price { get; set; }
    public DateTime RuleDate { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public uint ProductId { get; set; }
    public uint CustomerGroupId { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }
}