using Core.Application.Responses;

namespace Application.Features.CartRuleChannels.Queries.GetById;

public class GetByIdCartRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint ChannelId { get; set; }
}