using FluentValidation;

namespace Application.Features.BookingProducts.Commands.Update;

public class UpdateBookingProductCommandValidator : AbstractValidator<UpdateBookingProductCommand>
{
    public UpdateBookingProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Qty).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.ShowLocation).NotEmpty();
        RuleFor(c => c.AvailableEveryWeek).NotEmpty();
        RuleFor(c => c.AvailableFrom).NotEmpty();
        RuleFor(c => c.AvailableTo).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}