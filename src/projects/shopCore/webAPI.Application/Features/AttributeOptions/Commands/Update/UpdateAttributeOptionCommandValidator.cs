using FluentValidation;

namespace Application.Features.AttributeOptions.Commands.Update;

public class UpdateAttributeOptionCommandValidator : AbstractValidator<UpdateAttributeOptionCommand>
{
    public UpdateAttributeOptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AdminName).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
        RuleFor(c => c.AttributeId).NotEmpty();
        RuleFor(c => c.SwatchValue).NotEmpty();
    }
}