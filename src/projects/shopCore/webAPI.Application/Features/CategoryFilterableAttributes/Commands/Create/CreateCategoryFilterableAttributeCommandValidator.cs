using FluentValidation;

namespace Application.Features.CategoryFilterableAttributes.Commands.Create;

public class CreateCategoryFilterableAttributeCommandValidator : AbstractValidator<CreateCategoryFilterableAttributeCommand>
{
    public CreateCategoryFilterableAttributeCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.AttributeId).NotEmpty();
    }
}