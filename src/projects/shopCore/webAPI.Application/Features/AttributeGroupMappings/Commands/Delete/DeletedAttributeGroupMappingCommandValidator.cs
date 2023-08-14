using FluentValidation;

namespace Application.Features.AttributeGroupMappings.Commands.Delete;

public class DeleteAttributeGroupMappingCommandValidator : AbstractValidator<DeleteAttributeGroupMappingCommand>
{
    public DeleteAttributeGroupMappingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}