using Core.Application.Responses;

namespace Application.Features.CatalogRuleChannels.Commands.Update;

public class UpdatedCatalogRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }
}