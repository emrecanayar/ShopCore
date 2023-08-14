using Core.Application.Responses;

namespace Application.Features.CartRules.Commands.Delete;

public class DeletedCartRuleResponse : IResponse
{
    public uint Id { get; set; }
}