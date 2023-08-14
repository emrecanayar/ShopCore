using FluentValidation;

namespace Application.Features.Attributes.Commands.Update;

public class UpdateAttributeCommandValidator : AbstractValidator<UpdateAttributeCommand>
{
    public UpdateAttributeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.AdminName).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Validation).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.IsRequired).NotEmpty();
        RuleFor(c => c.IsUnique).NotEmpty();
        RuleFor(c => c.ValuePerLocale).NotEmpty();
        RuleFor(c => c.ValuePerChannel).NotEmpty();
        RuleFor(c => c.IsFilterable).NotEmpty();
        RuleFor(c => c.IsConfigurable).NotEmpty();
        RuleFor(c => c.IsUserDefined).NotEmpty();
        RuleFor(c => c.IsVisibleOnFront).NotEmpty();
        RuleFor(c => c.SwatchType).NotEmpty();
        RuleFor(c => c.UseInFlat).NotEmpty();
        RuleFor(c => c.IsComparable).NotEmpty();
        RuleFor(c => c.EnableWysiwyg).NotEmpty();
    }
}