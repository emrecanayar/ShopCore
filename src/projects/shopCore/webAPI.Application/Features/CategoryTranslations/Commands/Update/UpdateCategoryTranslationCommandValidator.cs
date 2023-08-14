using FluentValidation;

namespace Application.Features.CategoryTranslations.Commands.Update;

public class UpdateCategoryTranslationCommandValidator : AbstractValidator<UpdateCategoryTranslationCommand>
{
    public UpdateCategoryTranslationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Slug).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.MetaTitle).NotEmpty();
        RuleFor(c => c.MetaDescription).NotEmpty();
        RuleFor(c => c.MetaKeywords).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Locale).NotEmpty();
        RuleFor(c => c.LocaleId).NotEmpty();
        RuleFor(c => c.UrlPath).NotEmpty();
    }
}