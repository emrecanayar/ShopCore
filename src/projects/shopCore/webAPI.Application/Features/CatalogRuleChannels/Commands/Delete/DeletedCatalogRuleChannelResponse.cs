using Core.Application.Responses;

namespace Application.Features.CatalogRuleChannels.Commands.Delete;

public class DeletedCatalogRuleChannelResponse : IResponse
{
    public uint Id { get; set; }
}