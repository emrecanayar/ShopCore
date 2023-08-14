using FluentValidation;

namespace Application.Features.BookingProductRentalSlots.Commands.Create;

public class CreateBookingProductRentalSlotCommandValidator : AbstractValidator<CreateBookingProductRentalSlotCommand>
{
    public CreateBookingProductRentalSlotCommandValidator()
    {
        RuleFor(c => c.RentingType).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.HourlyPrice).NotEmpty();
        RuleFor(c => c.SameSlotAllDays).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}