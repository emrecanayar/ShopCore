using FluentValidation;

namespace Application.Features.AttributeGroups.Commands.Create;

public class CreateAttributeGroupCommandValidator : AbstractValidator<CreateAttributeGroupCommand>
{
    public CreateAttributeGroupCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.IsUserDefined).NotEmpty();
        RuleFor(c => c.AttributeFamilyId).NotEmpty();
    }
}