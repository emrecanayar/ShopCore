using Application.Features.BookingProductAppointmentSlots.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductAppointmentSlots;

public class BookingProductAppointmentSlotsManager : IBookingProductAppointmentSlotsService
{
    private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
    private readonly BookingProductAppointmentSlotBusinessRules _bookingProductAppointmentSlotBusinessRules;

    public BookingProductAppointmentSlotsManager(IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository, BookingProductAppointmentSlotBusinessRules bookingProductAppointmentSlotBusinessRules)
    {
        _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
        _bookingProductAppointmentSlotBusinessRules = bookingProductAppointmentSlotBusinessRules;
    }

    public async Task<BookingProductAppointmentSlot?> GetAsync(
        Expression<Func<BookingProductAppointmentSlot, bool>> predicate,
        Func<IQueryable<BookingProductAppointmentSlot>, IIncludableQueryable<BookingProductAppointmentSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductAppointmentSlot? bookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductAppointmentSlot;
    }

    public async Task<IPaginate<BookingProductAppointmentSlot>?> GetListAsync(
        Expression<Func<BookingProductAppointmentSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductAppointmentSlot>, IOrderedQueryable<BookingProductAppointmentSlot>>? orderBy = null,
        Func<IQueryable<BookingProductAppointmentSlot>, IIncludableQueryable<BookingProductAppointmentSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductAppointmentSlot> bookingProductAppointmentSlotList = await _bookingProductAppointmentSlotRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductAppointmentSlotList;
    }

    public async Task<BookingProductAppointmentSlot> AddAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot)
    {
        BookingProductAppointmentSlot addedBookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.AddAsync(bookingProductAppointmentSlot);

        return addedBookingProductAppointmentSlot;
    }

    public async Task<BookingProductAppointmentSlot> UpdateAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot)
    {
        BookingProductAppointmentSlot updatedBookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.UpdateAsync(bookingProductAppointmentSlot);

        return updatedBookingProductAppointmentSlot;
    }

    public async Task<BookingProductAppointmentSlot> DeleteAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot, bool permanent = false)
    {
        BookingProductAppointmentSlot deletedBookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.DeleteAsync(bookingProductAppointmentSlot);

        return deletedBookingProductAppointmentSlot;
    }
}
