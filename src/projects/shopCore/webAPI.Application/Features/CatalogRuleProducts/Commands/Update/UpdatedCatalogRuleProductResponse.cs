using Core.Application.Responses;

namespace Application.Features.CatalogRuleProducts.Commands.Update;

public class UpdatedCatalogRuleProductResponse : IResponse
{
    public uint Id { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool EndOtherRules { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public uint SortOrder { get; set; }
    public uint ProductId { get; set; }
    public uint CustomerGroupId { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }
}