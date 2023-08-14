using Application.Features.CartRuleCustomers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleCustomers;

public class CartRuleCustomersManager : ICartRuleCustomersService
{
    private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
    private readonly CartRuleCustomerBusinessRules _cartRuleCustomerBusinessRules;

    public CartRuleCustomersManager(ICartRuleCustomerRepository cartRuleCustomerRepository, CartRuleCustomerBusinessRules cartRuleCustomerBusinessRules)
    {
        _cartRuleCustomerRepository = cartRuleCustomerRepository;
        _cartRuleCustomerBusinessRules = cartRuleCustomerBusinessRules;
    }

    public async Task<CartRuleCustomer?> GetAsync(
        Expression<Func<CartRuleCustomer, bool>> predicate,
        Func<IQueryable<CartRuleCustomer>, IIncludableQueryable<CartRuleCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleCustomer? cartRuleCustomer = await _cartRuleCustomerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleCustomer;
    }

    public async Task<IPaginate<CartRuleCustomer>?> GetListAsync(
        Expression<Func<CartRuleCustomer, bool>>? predicate = null,
        Func<IQueryable<CartRuleCustomer>, IOrderedQueryable<CartRuleCustomer>>? orderBy = null,
        Func<IQueryable<CartRuleCustomer>, IIncludableQueryable<CartRuleCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleCustomer> cartRuleCustomerList = await _cartRuleCustomerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleCustomerList;
    }

    public async Task<CartRuleCustomer> AddAsync(CartRuleCustomer cartRuleCustomer)
    {
        CartRuleCustomer addedCartRuleCustomer = await _cartRuleCustomerRepository.AddAsync(cartRuleCustomer);

        return addedCartRuleCustomer;
    }

    public async Task<CartRuleCustomer> UpdateAsync(CartRuleCustomer cartRuleCustomer)
    {
        CartRuleCustomer updatedCartRuleCustomer = await _cartRuleCustomerRepository.UpdateAsync(cartRuleCustomer);

        return updatedCartRuleCustomer;
    }

    public async Task<CartRuleCustomer> DeleteAsync(CartRuleCustomer cartRuleCustomer, bool permanent = false)
    {
        CartRuleCustomer deletedCartRuleCustomer = await _cartRuleCustomerRepository.DeleteAsync(cartRuleCustomer);

        return deletedCartRuleCustomer;
    }
}
