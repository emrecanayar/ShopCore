using Application.Features.BookingProductTableSlots.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductTableSlots;

public class BookingProductTableSlotsManager : IBookingProductTableSlotsService
{
    private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
    private readonly BookingProductTableSlotBusinessRules _bookingProductTableSlotBusinessRules;

    public BookingProductTableSlotsManager(IBookingProductTableSlotRepository bookingProductTableSlotRepository, BookingProductTableSlotBusinessRules bookingProductTableSlotBusinessRules)
    {
        _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
        _bookingProductTableSlotBusinessRules = bookingProductTableSlotBusinessRules;
    }

    public async Task<BookingProductTableSlot?> GetAsync(
        Expression<Func<BookingProductTableSlot, bool>> predicate,
        Func<IQueryable<BookingProductTableSlot>, IIncludableQueryable<BookingProductTableSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductTableSlot? bookingProductTableSlot = await _bookingProductTableSlotRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductTableSlot;
    }

    public async Task<IPaginate<BookingProductTableSlot>?> GetListAsync(
        Expression<Func<BookingProductTableSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductTableSlot>, IOrderedQueryable<BookingProductTableSlot>>? orderBy = null,
        Func<IQueryable<BookingProductTableSlot>, IIncludableQueryable<BookingProductTableSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductTableSlot> bookingProductTableSlotList = await _bookingProductTableSlotRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductTableSlotList;
    }

    public async Task<BookingProductTableSlot> AddAsync(BookingProductTableSlot bookingProductTableSlot)
    {
        BookingProductTableSlot addedBookingProductTableSlot = await _bookingProductTableSlotRepository.AddAsync(bookingProductTableSlot);

        return addedBookingProductTableSlot;
    }

    public async Task<BookingProductTableSlot> UpdateAsync(BookingProductTableSlot bookingProductTableSlot)
    {
        BookingProductTableSlot updatedBookingProductTableSlot = await _bookingProductTableSlotRepository.UpdateAsync(bookingProductTableSlot);

        return updatedBookingProductTableSlot;
    }

    public async Task<BookingProductTableSlot> DeleteAsync(BookingProductTableSlot bookingProductTableSlot, bool permanent = false)
    {
        BookingProductTableSlot deletedBookingProductTableSlot = await _bookingProductTableSlotRepository.DeleteAsync(bookingProductTableSlot);

        return deletedBookingProductTableSlot;
    }
}
