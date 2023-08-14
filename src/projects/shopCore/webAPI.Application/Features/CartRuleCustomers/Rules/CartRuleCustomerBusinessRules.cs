using Application.Features.CartRuleCustomers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleCustomers.Rules;

public class CartRuleCustomerBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;

    public CartRuleCustomerBusinessRules(ICartRuleCustomerRepository cartRuleCustomerRepository)
    {
        _cartRuleCustomerRepository = cartRuleCustomerRepository;
    }

    public Task CartRuleCustomerShouldExistWhenSelected(CartRuleCustomer? cartRuleCustomer)
    {
        if (cartRuleCustomer == null)
            throw new BusinessException(CartRuleCustomersBusinessMessages.CartRuleCustomerNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleCustomerIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleCustomer? cartRuleCustomer = await _cartRuleCustomerRepository.GetAsync(
            predicate: crc => crc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleCustomerShouldExistWhenSelected(cartRuleCustomer);
    }
}