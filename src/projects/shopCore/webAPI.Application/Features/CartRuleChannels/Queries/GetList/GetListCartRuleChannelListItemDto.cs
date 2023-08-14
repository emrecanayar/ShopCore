using Core.Application.Dtos;

namespace Application.Features.CartRuleChannels.Queries.GetList;

public class GetListCartRuleChannelListItemDto : IDto
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint ChannelId { get; set; }
}