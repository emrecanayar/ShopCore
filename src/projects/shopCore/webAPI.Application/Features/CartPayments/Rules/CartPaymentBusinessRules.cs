using Application.Features.CartPayments.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartPayments.Rules;

public class CartPaymentBusinessRules : BaseBusinessRules
{
    private readonly ICartPaymentRepository _cartPaymentRepository;

    public CartPaymentBusinessRules(ICartPaymentRepository cartPaymentRepository)
    {
        _cartPaymentRepository = cartPaymentRepository;
    }

    public Task CartPaymentShouldExistWhenSelected(CartPayment? cartPayment)
    {
        if (cartPayment == null)
            throw new BusinessException(CartPaymentsBusinessMessages.CartPaymentNotExists);
        return Task.CompletedTask;
    }

    public async Task CartPaymentIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartPayment? cartPayment = await _cartPaymentRepository.GetAsync(
            predicate: cp => cp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartPaymentShouldExistWhenSelected(cartPayment);
    }
}