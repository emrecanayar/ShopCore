using FluentValidation;

namespace Application.Features.AttributeOptions.Commands.Delete;

public class DeleteAttributeOptionCommandValidator : AbstractValidator<DeleteAttributeOptionCommand>
{
    public DeleteAttributeOptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}