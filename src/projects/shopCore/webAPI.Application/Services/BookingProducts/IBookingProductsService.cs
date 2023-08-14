using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProducts;

public interface IBookingProductsService
{
    Task<BookingProduct?> GetAsync(
        Expression<Func<BookingProduct, bool>> predicate,
        Func<IQueryable<BookingProduct>, IIncludableQueryable<BookingProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookingProduct>?> GetListAsync(
        Expression<Func<BookingProduct, bool>>? predicate = null,
        Func<IQueryable<BookingProduct>, IOrderedQueryable<BookingProduct>>? orderBy = null,
        Func<IQueryable<BookingProduct>, IIncludableQueryable<BookingProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookingProduct> AddAsync(BookingProduct bookingProduct);
    Task<BookingProduct> UpdateAsync(BookingProduct bookingProduct);
    Task<BookingProduct> DeleteAsync(BookingProduct bookingProduct, bool permanent = false);
}
