using FluentValidation;

namespace Application.Features.CategoryFilterableAttributes.Commands.Update;

public class UpdateCategoryFilterableAttributeCommandValidator : AbstractValidator<UpdateCategoryFilterableAttributeCommand>
{
    public UpdateCategoryFilterableAttributeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.AttributeId).NotEmpty();
    }
}