using FluentValidation;

namespace Application.Features.CatalogRuleChannels.Commands.Create;

public class CreateCatalogRuleChannelCommandValidator : AbstractValidator<CreateCatalogRuleChannelCommand>
{
    public CreateCatalogRuleChannelCommandValidator()
    {
        RuleFor(c => c.CatalogRuleId).NotEmpty();
        RuleFor(c => c.ChannelId).NotEmpty();
    }
}