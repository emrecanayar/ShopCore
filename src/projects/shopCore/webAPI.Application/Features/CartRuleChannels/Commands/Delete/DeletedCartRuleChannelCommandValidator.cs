using FluentValidation;

namespace Application.Features.CartRuleChannels.Commands.Delete;

public class DeleteCartRuleChannelCommandValidator : AbstractValidator<DeleteCartRuleChannelCommand>
{
    public DeleteCartRuleChannelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}