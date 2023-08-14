using Application.Features.BookingProductEventTickets.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductEventTickets.Rules;

public class BookingProductEventTicketBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;

    public BookingProductEventTicketBusinessRules(IBookingProductEventTicketRepository bookingProductEventTicketRepository)
    {
        _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
    }

    public Task BookingProductEventTicketShouldExistWhenSelected(BookingProductEventTicket? bookingProductEventTicket)
    {
        if (bookingProductEventTicket == null)
            throw new BusinessException(BookingProductEventTicketsBusinessMessages.BookingProductEventTicketNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductEventTicketIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductEventTicket? bookingProductEventTicket = await _bookingProductEventTicketRepository.GetAsync(
            predicate: bpet => bpet.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductEventTicketShouldExistWhenSelected(bookingProductEventTicket);
    }
}