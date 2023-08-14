using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductRentalSlots;

public interface IBookingProductRentalSlotsService
{
    Task<BookingProductRentalSlot?> GetAsync(
        Expression<Func<BookingProductRentalSlot, bool>> predicate,
        Func<IQueryable<BookingProductRentalSlot>, IIncludableQueryable<BookingProductRentalSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductRentalSlot>?> GetListAsync(
        Expression<Func<BookingProductRentalSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductRentalSlot>, IOrderedQueryable<BookingProductRentalSlot>>? orderBy = null,
        Func<IQueryable<BookingProductRentalSlot>, IIncludableQueryable<BookingProductRentalSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductRentalSlot> AddAsync(BookingProductRentalSlot bookingProductRentalSlot);
    Task<BookingProductRentalSlot> UpdateAsync(BookingProductRentalSlot bookingProductRentalSlot);
    Task<BookingProductRentalSlot> DeleteAsync(BookingProductRentalSlot bookingProductRentalSlot, bool permanent = false);
}
