using Core.Application.Responses;

namespace Application.Features.CartRuleChannels.Commands.Update;

public class UpdatedCartRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint ChannelId { get; set; }
}