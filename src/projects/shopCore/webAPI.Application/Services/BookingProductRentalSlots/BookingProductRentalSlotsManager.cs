using Application.Features.BookingProductRentalSlots.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductRentalSlots;

public class BookingProductRentalSlotsManager : IBookingProductRentalSlotsService
{
    private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
    private readonly BookingProductRentalSlotBusinessRules _bookingProductRentalSlotBusinessRules;

    public BookingProductRentalSlotsManager(IBookingProductRentalSlotRepository bookingProductRentalSlotRepository, BookingProductRentalSlotBusinessRules bookingProductRentalSlotBusinessRules)
    {
        _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
        _bookingProductRentalSlotBusinessRules = bookingProductRentalSlotBusinessRules;
    }

    public async Task<BookingProductRentalSlot?> GetAsync(
        Expression<Func<BookingProductRentalSlot, bool>> predicate,
        Func<IQueryable<BookingProductRentalSlot>, IIncludableQueryable<BookingProductRentalSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductRentalSlot? bookingProductRentalSlot = await _bookingProductRentalSlotRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductRentalSlot;
    }

    public async Task<IPaginate<BookingProductRentalSlot>?> GetListAsync(
        Expression<Func<BookingProductRentalSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductRentalSlot>, IOrderedQueryable<BookingProductRentalSlot>>? orderBy = null,
        Func<IQueryable<BookingProductRentalSlot>, IIncludableQueryable<BookingProductRentalSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductRentalSlot> bookingProductRentalSlotList = await _bookingProductRentalSlotRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductRentalSlotList;
    }

    public async Task<BookingProductRentalSlot> AddAsync(BookingProductRentalSlot bookingProductRentalSlot)
    {
        BookingProductRentalSlot addedBookingProductRentalSlot = await _bookingProductRentalSlotRepository.AddAsync(bookingProductRentalSlot);

        return addedBookingProductRentalSlot;
    }

    public async Task<BookingProductRentalSlot> UpdateAsync(BookingProductRentalSlot bookingProductRentalSlot)
    {
        BookingProductRentalSlot updatedBookingProductRentalSlot = await _bookingProductRentalSlotRepository.UpdateAsync(bookingProductRentalSlot);

        return updatedBookingProductRentalSlot;
    }

    public async Task<BookingProductRentalSlot> DeleteAsync(BookingProductRentalSlot bookingProductRentalSlot, bool permanent = false)
    {
        BookingProductRentalSlot deletedBookingProductRentalSlot = await _bookingProductRentalSlotRepository.DeleteAsync(bookingProductRentalSlot);

        return deletedBookingProductRentalSlot;
    }
}
