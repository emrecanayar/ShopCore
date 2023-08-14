using FluentValidation;

namespace Application.Features.CatalogRuleChannels.Commands.Update;

public class UpdateCatalogRuleChannelCommandValidator : AbstractValidator<UpdateCatalogRuleChannelCommand>
{
    public UpdateCatalogRuleChannelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}