using FluentValidation;

namespace Application.Features.CategoryFilterableAttributes.Commands.Delete;

public class DeleteCategoryFilterableAttributeCommandValidator : AbstractValidator<DeleteCategoryFilterableAttributeCommand>
{
    public DeleteCategoryFilterableAttributeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}