using FluentValidation;

namespace Application.Features.AttributeGroupMappings.Commands.Update;

public class UpdateAttributeGroupMappingCommandValidator : AbstractValidator<UpdateAttributeGroupMappingCommand>
{
    public UpdateAttributeGroupMappingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AttributeId).NotEmpty();
        RuleFor(c => c.AttributeGroupId).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
    }
}