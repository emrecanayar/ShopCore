using Application.Features.BookingProductAppointmentSlots.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductAppointmentSlots.Rules;

public class BookingProductAppointmentSlotBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;

    public BookingProductAppointmentSlotBusinessRules(IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository)
    {
        _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
    }

    public Task BookingProductAppointmentSlotShouldExistWhenSelected(BookingProductAppointmentSlot? bookingProductAppointmentSlot)
    {
        if (bookingProductAppointmentSlot == null)
            throw new BusinessException(BookingProductAppointmentSlotsBusinessMessages.BookingProductAppointmentSlotNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductAppointmentSlotIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductAppointmentSlot? bookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.GetAsync(
            predicate: bpas => bpas.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductAppointmentSlotShouldExistWhenSelected(bookingProductAppointmentSlot);
    }
}