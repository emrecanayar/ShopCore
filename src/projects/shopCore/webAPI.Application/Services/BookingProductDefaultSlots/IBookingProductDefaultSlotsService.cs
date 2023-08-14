using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductDefaultSlots;

public interface IBookingProductDefaultSlotsService
{
    Task<BookingProductDefaultSlot?> GetAsync(
        Expression<Func<BookingProductDefaultSlot, bool>> predicate,
        Func<IQueryable<BookingProductDefaultSlot>, IIncludableQueryable<BookingProductDefaultSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductDefaultSlot>?> GetListAsync(
        Expression<Func<BookingProductDefaultSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductDefaultSlot>, IOrderedQueryable<BookingProductDefaultSlot>>? orderBy = null,
        Func<IQueryable<BookingProductDefaultSlot>, IIncludableQueryable<BookingProductDefaultSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductDefaultSlot> AddAsync(BookingProductDefaultSlot bookingProductDefaultSlot);
    Task<BookingProductDefaultSlot> UpdateAsync(BookingProductDefaultSlot bookingProductDefaultSlot);
    Task<BookingProductDefaultSlot> DeleteAsync(BookingProductDefaultSlot bookingProductDefaultSlot, bool permanent = false);
}
