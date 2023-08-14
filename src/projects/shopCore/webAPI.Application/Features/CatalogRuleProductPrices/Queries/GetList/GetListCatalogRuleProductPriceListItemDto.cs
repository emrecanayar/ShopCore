using Core.Application.Dtos;

namespace Application.Features.CatalogRuleProductPrices.Queries.GetList;

public class GetListCatalogRuleProductPriceListItemDto : IDto
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