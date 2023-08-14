using FluentValidation;

namespace Application.Features.AttributeFamilies.Commands.Update;

public class UpdateAttributeFamilyCommandValidator : AbstractValidator<UpdateAttributeFamilyCommand>
{
    public UpdateAttributeFamilyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.IsUserDefined).NotEmpty();
    }
}