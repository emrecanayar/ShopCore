using Application.Features.BookingProducts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProducts;

public class BookingProductsManager : IBookingProductsService
{
    private readonly IBookingProductRepository _bookingProductRepository;
    private readonly BookingProductBusinessRules _bookingProductBusinessRules;

    public BookingProductsManager(IBookingProductRepository bookingProductRepository, BookingProductBusinessRules bookingProductBusinessRules)
    {
        _bookingProductRepository = bookingProductRepository;
        _bookingProductBusinessRules = bookingProductBusinessRules;
    }

    public async Task<BookingProduct?> GetAsync(
        Expression<Func<BookingProduct, bool>> predicate,
        Func<IQueryable<BookingProduct>, IIncludableQueryable<BookingProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProduct? bookingProduct = await _bookingProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProduct;
    }

    public async Task<IPaginate<BookingProduct>?> GetListAsync(
        Expression<Func<BookingProduct, bool>>? predicate = null,
        Func<IQueryable<BookingProduct>, IOrderedQueryable<BookingProduct>>? orderBy = null,
        Func<IQueryable<BookingProduct>, IIncludableQueryable<BookingProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProduct> bookingProductList = await _bookingProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductList;
    }

    public async Task<BookingProduct> AddAsync(BookingProduct bookingProduct)
    {
        BookingProduct addedBookingProduct = await _bookingProductRepository.AddAsync(bookingProduct);

        return addedBookingProduct;
    }

    public async Task<BookingProduct> UpdateAsync(BookingProduct bookingProduct)
    {
        BookingProduct updatedBookingProduct = await _bookingProductRepository.UpdateAsync(bookingProduct);

        return updatedBookingProduct;
    }

    public async Task<BookingProduct> DeleteAsync(BookingProduct bookingProduct, bool permanent = false)
    {
        BookingProduct deletedBookingProduct = await _bookingProductRepository.DeleteAsync(bookingProduct);

        return deletedBookingProduct;
    }
}
