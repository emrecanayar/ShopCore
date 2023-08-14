using FluentValidation;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.Image).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Lft).NotEmpty();
        RuleFor(c => c.Rgt).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.DisplayMode).NotEmpty();
        RuleFor(c => c.CategoryIconPath).NotEmpty();
        RuleFor(c => c.Additional).NotEmpty();
    }
}