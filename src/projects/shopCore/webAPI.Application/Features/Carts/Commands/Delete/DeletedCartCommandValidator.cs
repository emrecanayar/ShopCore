using FluentValidation;

namespace Application.Features.Carts.Commands.Delete;

public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}