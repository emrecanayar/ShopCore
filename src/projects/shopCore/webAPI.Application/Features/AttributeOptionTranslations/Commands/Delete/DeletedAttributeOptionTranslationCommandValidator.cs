using FluentValidation;

namespace Application.Features.AttributeOptionTranslations.Commands.Delete;

public class DeleteAttributeOptionTranslationCommandValidator : AbstractValidator<DeleteAttributeOptionTranslationCommand>
{
    public DeleteAttributeOptionTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}