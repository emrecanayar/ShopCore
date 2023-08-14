using FluentValidation;

namespace Application.Features.AttributeOptions.Commands.Create;

public class CreateAttributeOptionCommandValidator : AbstractValidator<CreateAttributeOptionCommand>
{
    public CreateAttributeOptionCommandValidator()
    {
        RuleFor(c => c.AdminName).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
        RuleFor(c => c.AttributeId).NotEmpty();
        RuleFor(c => c.SwatchValue).NotEmpty();
    }
}