using Core.Application.Responses;

namespace Application.Features.CatalogRuleChannels.Queries.GetById;

public class GetByIdCatalogRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }
}