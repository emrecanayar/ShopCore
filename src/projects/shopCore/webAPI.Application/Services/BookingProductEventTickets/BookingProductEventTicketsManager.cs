using Application.Features.BookingProductEventTickets.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookingProductEventTickets;

public class BookingProductEventTicketsManager : IBookingProductEventTicketsService
{
    private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
    private readonly BookingProductEventTicketBusinessRules _bookingProductEventTicketBusinessRules;

    public BookingProductEventTicketsManager(IBookingProductEventTicketRepository bookingProductEventTicketRepository, BookingProductEventTicketBusinessRules bookingProductEventTicketBusinessRules)
    {
        _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
        _bookingProductEventTicketBusinessRules = bookingProductEventTicketBusinessRules;
    }

    public async Task<BookingProductEventTicket?> GetAsync(
        Expression<Func<BookingProductEventTicket, bool>> predicate,
        Func<IQueryable<BookingProductEventTicket>, IIncludableQueryable<BookingProductEventTicket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookingProductEventTicket? bookingProductEventTicket = await _bookingProductEventTicketRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookingProductEventTicket;
    }

    public async Task<IPaginate<BookingProductEventTicket>?> GetListAsync(
        Expression<Func<BookingProductEventTicket, bool>>? predicate = null,
        Func<IQueryable<BookingProductEventTicket>, IOrderedQueryable<BookingProductEventTicket>>? orderBy = null,
        Func<IQueryable<BookingProductEventTicket>, IIncludableQueryable<BookingProductEventTicket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookingProductEventTicket> bookingProductEventTicketList = await _bookingProductEventTicketRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookingProductEventTicketList;
    }

    public async Task<BookingProductEventTicket> AddAsync(BookingProductEventTicket bookingProductEventTicket)
    {
        BookingProductEventTicket addedBookingProductEventTicket = await _bookingProductEventTicketRepository.AddAsync(bookingProductEventTicket);

        return addedBookingProductEventTicket;
    }

    public async Task<BookingProductEventTicket> UpdateAsync(BookingProductEventTicket bookingProductEventTicket)
    {
        BookingProductEventTicket updatedBookingProductEventTicket = await _bookingProductEventTicketRepository.UpdateAsync(bookingProductEventTicket);

        return updatedBookingProductEventTicket;
    }

    public async Task<BookingProductEventTicket> DeleteAsync(BookingProductEventTicket bookingProductEventTicket, bool permanent = false)
    {
        BookingProductEventTicket deletedBookingProductEventTicket = await _bookingProductEventTicketRepository.DeleteAsync(bookingProductEventTicket);

        return deletedBookingProductEventTicket;
    }
}
