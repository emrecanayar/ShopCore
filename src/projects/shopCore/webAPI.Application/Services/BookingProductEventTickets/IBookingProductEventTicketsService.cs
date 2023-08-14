using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductEventTickets;

public interface IBookingProductEventTicketsService
{
    Task<BookingProductEventTicket?> GetAsync(
        Expression<Func<BookingProductEventTicket, bool>> predicate,
        Func<IQueryable<BookingProductEventTicket>, IIncludableQueryable<BookingProductEventTicket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductEventTicket>?> GetListAsync(
        Expression<Func<BookingProductEventTicket, bool>>? predicate = null,
        Func<IQueryable<BookingProductEventTicket>, IOrderedQueryable<BookingProductEventTicket>>? orderBy = null,
        Func<IQueryable<BookingProductEventTicket>, IIncludableQueryable<BookingProductEventTicket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductEventTicket> AddAsync(BookingProductEventTicket bookingProductEventTicket);
    Task<BookingProductEventTicket> UpdateAsync(BookingProductEventTicket bookingProductEventTicket);
    Task<BookingProductEventTicket> DeleteAsync(BookingProductEventTicket bookingProductEventTicket, bool permanent = false);
}
