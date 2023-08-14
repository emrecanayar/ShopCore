using Application.Features.BookingProductDefaultSlots.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductDefaultSlots.Rules;

public class BookingProductDefaultSlotBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;

    public BookingProductDefaultSlotBusinessRules(IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository)
    {
        _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
    }

    public Task BookingProductDefaultSlotShouldExistWhenSelected(BookingProductDefaultSlot? bookingProductDefaultSlot)
    {
        if (bookingProductDefaultSlot == null)
            throw new BusinessException(BookingProductDefaultSlotsBusinessMessages.BookingProductDefaultSlotNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductDefaultSlotIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductDefaultSlot? bookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.GetAsync(
            predicate: bpds => bpds.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductDefaultSlotShouldExistWhenSelected(bookingProductDefaultSlot);
    }
}