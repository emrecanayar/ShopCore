using FluentValidation;

namespace Application.Features.Attributes.Commands.Delete;

public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeCommand>
{
    public DeleteAttributeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}