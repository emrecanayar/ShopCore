using FluentValidation;

namespace Application.Features.AttributeGroups.Commands.Update;

public class UpdateAttributeGroupCommandValidator : AbstractValidator<UpdateAttributeGroupCommand>
{
    public UpdateAttributeGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.IsUserDefined).NotEmpty();
        RuleFor(c => c.AttributeFamilyId).NotEmpty();
    }
}