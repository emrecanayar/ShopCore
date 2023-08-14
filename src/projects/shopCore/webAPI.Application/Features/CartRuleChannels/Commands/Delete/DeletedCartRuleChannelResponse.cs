using Core.Application.Responses;

namespace Application.Features.CartRuleChannels.Commands.Delete;

public class DeletedCartRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
}