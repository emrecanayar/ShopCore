using Application.Features.BookingProductRentalSlots.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductRentalSlots.Rules;

public class BookingProductRentalSlotBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;

    public BookingProductRentalSlotBusinessRules(IBookingProductRentalSlotRepository bookingProductRentalSlotRepository)
    {
        _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
    }

    public Task BookingProductRentalSlotShouldExistWhenSelected(BookingProductRentalSlot? bookingProductRentalSlot)
    {
        if (bookingProductRentalSlot == null)
            throw new BusinessException(BookingProductRentalSlotsBusinessMessages.BookingProductRentalSlotNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductRentalSlotIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductRentalSlot? bookingProductRentalSlot = await _bookingProductRentalSlotRepository.GetAsync(
            predicate: bprs => bprs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductRentalSlotShouldExistWhenSelected(bookingProductRentalSlot);
    }
}