using FluentValidation;

namespace Application.Features.AttributeGroupMappings.Commands.Create;

public class CreateAttributeGroupMappingCommandValidator : AbstractValidator<CreateAttributeGroupMappingCommand>
{
    public CreateAttributeGroupMappingCommandValidator()
    {
        RuleFor(c => c.AttributeId).NotEmpty();
        RuleFor(c => c.AttributeGroupId).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
    }
}