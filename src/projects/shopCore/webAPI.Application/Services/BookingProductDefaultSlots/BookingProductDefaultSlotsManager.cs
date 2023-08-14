using Application.Features.BookingProductDefaultSlots.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductDefaultSlots;

public class BookingProductDefaultSlotsManager : IBookingProductDefaultSlotsService
{
    private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
    private readonly BookingProductDefaultSlotBusinessRules _bookingProductDefaultSlotBusinessRules;

    public BookingProductDefaultSlotsManager(IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository, BookingProductDefaultSlotBusinessRules bookingProductDefaultSlotBusinessRules)
    {
        _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
        _bookingProductDefaultSlotBusinessRules = bookingProductDefaultSlotBusinessRules;
    }

    public async Task<BookingProductDefaultSlot?> GetAsync(
        Expression<Func<BookingProductDefaultSlot, bool>> predicate,
        Func<IQueryable<BookingProductDefaultSlot>, IIncludableQueryable<BookingProductDefaultSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductDefaultSlot? bookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductDefaultSlot;
    }

    public async Task<IPaginate<BookingProductDefaultSlot>?> GetListAsync(
        Expression<Func<BookingProductDefaultSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductDefaultSlot>, IOrderedQueryable<BookingProductDefaultSlot>>? orderBy = null,
        Func<IQueryable<BookingProductDefaultSlot>, IIncludableQueryable<BookingProductDefaultSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductDefaultSlot> bookingProductDefaultSlotList = await _bookingProductDefaultSlotRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductDefaultSlotList;
    }

    public async Task<BookingProductDefaultSlot> AddAsync(BookingProductDefaultSlot bookingProductDefaultSlot)
    {
        BookingProductDefaultSlot addedBookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.AddAsync(bookingProductDefaultSlot);

        return addedBookingProductDefaultSlot;
    }

    public async Task<BookingProductDefaultSlot> UpdateAsync(BookingProductDefaultSlot bookingProductDefaultSlot)
    {
        BookingProductDefaultSlot updatedBookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.UpdateAsync(bookingProductDefaultSlot);

        return updatedBookingProductDefaultSlot;
    }

    public async Task<BookingProductDefaultSlot> DeleteAsync(BookingProductDefaultSlot bookingProductDefaultSlot, bool permanent = false)
    {
        BookingProductDefaultSlot deletedBookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.DeleteAsync(bookingProductDefaultSlot);

        return deletedBookingProductDefaultSlot;
    }
}
