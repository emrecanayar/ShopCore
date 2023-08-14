using FluentValidation;

namespace Application.Features.AttributeFamilies.Commands.Create;

public class CreateAttributeFamilyCommandValidator : AbstractValidator<CreateAttributeFamilyCommand>
{
    public CreateAttributeFamilyCommandValidator()
    {
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.IsUserDefined).NotEmpty();
    }
}