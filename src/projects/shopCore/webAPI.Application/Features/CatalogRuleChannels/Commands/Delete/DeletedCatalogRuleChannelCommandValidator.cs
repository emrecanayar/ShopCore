using FluentValidation;

namespace Application.Features.CatalogRuleChannels.Commands.Delete;

public class DeleteCatalogRuleChannelCommandValidator : AbstractValidator<DeleteCatalogRuleChannelCommand>
{
    public DeleteCatalogRuleChannelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}