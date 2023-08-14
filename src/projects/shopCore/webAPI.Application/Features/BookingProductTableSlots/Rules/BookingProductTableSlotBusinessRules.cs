using Application.Features.BookingProductTableSlots.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductTableSlots.Rules;

public class BookingProductTableSlotBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;

    public BookingProductTableSlotBusinessRules(IBookingProductTableSlotRepository bookingProductTableSlotRepository)
    {
        _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
    }

    public Task BookingProductTableSlotShouldExistWhenSelected(BookingProductTableSlot? bookingProductTableSlot)
    {
        if (bookingProductTableSlot == null)
            throw new BusinessException(BookingProductTableSlotsBusinessMessages.BookingProductTableSlotNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductTableSlotIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductTableSlot? bookingProductTableSlot = await _bookingProductTableSlotRepository.GetAsync(
            predicate: bpts => bpts.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductTableSlotShouldExistWhenSelected(bookingProductTableSlot);
    }
}