using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductEventTicketTranslations;

public interface IBookingProductEventTicketTranslationsService
{
    Task<BookingProductEventTicketTranslation?> GetAsync(
        Expression<Func<BookingProductEventTicketTranslation, bool>> predicate,
        Func<IQueryable<BookingProductEventTicketTranslation>, IIncludableQueryable<BookingProductEventTicketTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProductEventTicketTranslation>?> GetListAsync(
        Expression<Func<BookingProductEventTicketTranslation, bool>>? predicate = null,
        Func<IQueryable<BookingProductEventTicketTranslation>, IOrderedQueryable<BookingProductEventTicketTranslation>>? orderBy = null,
        Func<IQueryable<BookingProductEventTicketTranslation>, IIncludableQueryable<BookingProductEventTicketTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProductEventTicketTranslation> AddAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation);
    Task<BookingProductEventTicketTranslation> UpdateAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation);
    Task<BookingProductEventTicketTranslation> DeleteAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation, bool permanent = false);
}
