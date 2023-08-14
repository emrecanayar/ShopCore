using FluentValidation;

namespace Application.Features.CategoryTranslations.Commands.Delete;

public class DeleteCategoryTranslationCommandValidator : AbstractValidator<DeleteCategoryTranslationCommand>
{
    public DeleteCategoryTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}