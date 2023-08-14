using FluentValidation;

namespace Application.Features.BookingProductRentalSlots.Commands.Update;

public class UpdateBookingProductRentalSlotCommandValidator : AbstractValidator<UpdateBookingProductRentalSlotCommand>
{
    public UpdateBookingProductRentalSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RentingType).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.HourlyPrice).NotEmpty();
        RuleFor(c => c.SameSlotAllDays).NotEmpty();
        RuleFor(c => c.Slots).NotEmpty();
        RuleFor(c => c.BookingProductId).NotEmpty();
    }
}