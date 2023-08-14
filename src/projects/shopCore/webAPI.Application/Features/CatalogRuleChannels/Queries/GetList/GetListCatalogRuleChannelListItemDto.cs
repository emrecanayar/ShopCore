using Core.Application.Dtos;

namespace Application.Features.CatalogRuleChannels.Queries.GetList;

public class GetListCatalogRuleChannelListItemDto : IDto
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }
}