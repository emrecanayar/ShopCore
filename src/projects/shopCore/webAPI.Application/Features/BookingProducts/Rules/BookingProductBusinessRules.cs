using Application.Features.BookingProducts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.BookingProducts.Rules;

public class BookingProductBusinessRules : BaseBusinessRules
{
    private readonly IBookingProductRepository _bookingProductRepository;

    public BookingProductBusinessRules(IBookingProductRepository bookingProductRepository)
    {
        _bookingProductRepository = bookingProductRepository;
    }

    public Task BookingProductShouldExistWhenSelected(BookingProduct? bookingProduct)
    {
        if (bookingProduct == null)
            throw new BusinessException(BookingProductsBusinessMessages.BookingProductNotExists);
        return Task.CompletedTask;
    }

    public async Task BookingProductIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        BookingProduct? bookingProduct = await _bookingProductRepository.GetAsync(
            predicate: bp => bp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookingProductShouldExistWhenSelected(bookingProduct);
    }
}