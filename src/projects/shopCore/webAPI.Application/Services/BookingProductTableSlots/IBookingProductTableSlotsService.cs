using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductTableSlots;

public interface IBookingProductTableSlotsService
{
    Task<BookingProductTableSlot?> GetAsync(
        Expression<Func<BookingProductTableSlot, bool>> predicate,
        Func<IQueryable<BookingProductTableSlot>, IIncludableQueryable<BookingProductTableSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductTableSlot>?> GetListAsync(
        Expression<Func<BookingProductTableSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductTableSlot>, IOrderedQueryable<BookingProductTableSlot>>? orderBy = null,
        Func<IQueryable<BookingProductTableSlot>, IIncludableQueryable<BookingProductTableSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductTableSlot> AddAsync(BookingProductTableSlot bookingProductTableSlot);
    Task<BookingProductTableSlot> UpdateAsync(BookingProductTableSlot bookingProductTableSlot);
    Task<BookingProductTableSlot> DeleteAsync(BookingProductTableSlot bookingProductTableSlot, bool permanent = false);
}
