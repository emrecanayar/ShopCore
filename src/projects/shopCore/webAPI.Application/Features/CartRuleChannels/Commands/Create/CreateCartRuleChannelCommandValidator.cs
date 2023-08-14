using FluentValidation;

namespace Application.Features.CartRuleChannels.Commands.Create;

public class CreateCartRuleChannelCommandValidator : AbstractValidator<CreateCartRuleChannelCommand>
{
    public CreateCartRuleChannelCommandValidator()
    {
        RuleFor(c => c.CartRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}