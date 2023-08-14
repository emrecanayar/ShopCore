using FluentValidation;

namespace Application.Features.AttributeFamilies.Commands.Delete;

public class DeleteAttributeFamilyCommandValidator : AbstractValidator<DeleteAttributeFamilyCommand>
{
    public DeleteAttributeFamilyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}