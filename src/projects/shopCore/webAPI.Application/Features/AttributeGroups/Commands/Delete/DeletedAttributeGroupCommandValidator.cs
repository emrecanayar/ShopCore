using FluentValidation;

namespace Application.Features.AttributeGroups.Commands.Delete;

public class DeleteAttributeGroupCommandValidator : AbstractValidator<DeleteAttributeGroupCommand>
{
    public DeleteAttributeGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}