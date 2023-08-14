using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductAppointmentSlots;

public interface IBookingProductAppointmentSlotsService
{
    Task<BookingProductAppointmentSlot?> GetAsync(
        Expression<Func<BookingProductAppointmentSlot, bool>> predicate,
        Func<IQueryable<BookingProductAppointmentSlot>, IIncludableQueryable<BookingProductAppointmentSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductAppointmentSlot>?> GetListAsync(
        Expression<Func<BookingProductAppointmentSlot, bool>>? predicate = null,
        Func<IQueryable<BookingProductAppointmentSlot>, IOrderedQueryable<BookingProductAppointmentSlot>>? orderBy = null,
        Func<IQueryable<BookingProductAppointmentSlot>, IIncludableQueryable<BookingProductAppointmentSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductAppointmentSlot> AddAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot);
    Task<BookingProductAppointmentSlot> UpdateAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot);
    Task<BookingProductAppointmentSlot> DeleteAsync(BookingProductAppointmentSlot bookingProductAppointmentSlot, bool permanent = false);
}
