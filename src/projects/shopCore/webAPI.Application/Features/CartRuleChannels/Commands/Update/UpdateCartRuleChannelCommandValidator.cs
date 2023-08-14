using FluentValidation;

namespace Application.Features.CartRuleChannels.Commands.Update;

public class UpdateCartRuleChannelCommandValidator : AbstractValidator<UpdateCartRuleChannelCommand>
{
    public UpdateCartRuleChannelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}