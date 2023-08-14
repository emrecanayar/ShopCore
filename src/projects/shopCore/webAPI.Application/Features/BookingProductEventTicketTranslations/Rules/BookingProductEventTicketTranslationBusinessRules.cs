using Application.Features.BookingProductEventTicketTranslations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProductEventTicketTranslations.Rules;

public class BookingProductEventTicketTranslationBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;

    public BookingProductEventTicketTranslationBusinessRules(IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository)
    {
        _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
    }

    public Task BookingProductEventTicketTranslationShouldExistWhenSelected(BookingProductEventTicketTranslation? bookingProductEventTicketTranslation)
    {
        if (bookingProductEventTicketTranslation == null)
            throw new BusinessException(BookingProductEventTicketTranslationsBusinessMessages.BookingProductEventTicketTranslationNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductEventTicketTranslationIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProductEventTicketTranslation? bookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.GetAsync(
            predicate: bpett => bpett.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductEventTicketTranslationShouldExistWhenSelected(bookingProductEventTicketTranslation);
    }
}