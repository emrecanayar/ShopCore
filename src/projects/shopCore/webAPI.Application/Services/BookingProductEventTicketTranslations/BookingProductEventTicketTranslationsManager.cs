using Application.Features.BookingProductEventTicketTranslations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductEventTicketTranslations;

public class BookingProductEventTicketTranslationsManager : IBookingProductEventTicketTranslationsService
{
    private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
    private readonly BookingProductEventTicketTranslationBusinessRules _bookingProductEventTicketTranslationBusinessRules;

    public BookingProductEventTicketTranslationsManager(IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository, BookingProductEventTicketTranslationBusinessRules bookingProductEventTicketTranslationBusinessRules)
    {
        _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
        _bookingProductEventTicketTranslationBusinessRules = bookingProductEventTicketTranslationBusinessRules;
    }

    public async Task<BookingProductEventTicketTranslation?> GetAsync(
        Expression<Func<BookingProductEventTicketTranslation, bool>> predicate,
        Func<IQueryable<BookingProductEventTicketTranslation>, IIncludableQueryable<BookingProductEventTicketTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductEventTicketTranslation? bookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductEventTicketTranslation;
    }

    public async Task<IPaginate<BookingProductEventTicketTranslation>?> GetListAsync(
        Expression<Func<BookingProductEventTicketTranslation, bool>>? predicate = null,
        Func<IQueryable<BookingProductEventTicketTranslation>, IOrderedQueryable<BookingProductEventTicketTranslation>>? orderBy = null,
        Func<IQueryable<BookingProductEventTicketTranslation>, IIncludableQueryable<BookingProductEventTicketTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductEventTicketTranslation> bookingProductEventTicketTranslationList = await _bookingProductEventTicketTranslationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductEventTicketTranslationList;
    }

    public async Task<BookingProductEventTicketTranslation> AddAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation)
    {
        BookingProductEventTicketTranslation addedBookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.AddAsync(bookingProductEventTicketTranslation);

        return addedBookingProductEventTicketTranslation;
    }

    public async Task<BookingProductEventTicketTranslation> UpdateAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation)
    {
        BookingProductEventTicketTranslation updatedBookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.UpdateAsync(bookingProductEventTicketTranslation);

        return updatedBookingProductEventTicketTranslation;
    }

    public async Task<BookingProductEventTicketTranslation> DeleteAsync(BookingProductEventTicketTranslation bookingProductEventTicketTranslation, bool permanent = false)
    {
        BookingProductEventTicketTranslation deletedBookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.DeleteAsync(bookingProductEventTicketTranslation);

        return deletedBookingProductEventTicketTranslation;
    }
}
