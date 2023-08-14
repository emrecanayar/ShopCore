using FluentValidation;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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