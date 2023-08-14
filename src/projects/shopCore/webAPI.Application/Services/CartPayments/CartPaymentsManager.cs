using Application.Features.CartPayments.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartPayments;

public class CartPaymentsManager : ICartPaymentsService
{
    private readonly ICartPaymentRepository _cartPaymentRepository;
    private readonly CartPaymentBusinessRules _cartPaymentBusinessRules;

    public CartPaymentsManager(ICartPaymentRepository cartPaymentRepository, CartPaymentBusinessRules cartPaymentBusinessRules)
    {
        _cartPaymentRepository = cartPaymentRepository;
        _cartPaymentBusinessRules = cartPaymentBusinessRules;
    }

    public async Task<CartPayment?> GetAsync(
        Expression<Func<CartPayment, bool>> predicate,
        Func<IQueryable<CartPayment>, IIncludableQueryable<CartPayment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartPayment? cartPayment = await _cartPaymentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartPayment;
    }

    public async Task<IPaginate<CartPayment>?> GetListAsync(
        Expression<Func<CartPayment, bool>>? predicate = null,
        Func<IQueryable<CartPayment>, IOrderedQueryable<CartPayment>>? orderBy = null,
        Func<IQueryable<CartPayment>, IIncludableQueryable<CartPayment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartPayment> cartPaymentList = await _cartPaymentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartPaymentList;
    }

    public async Task<CartPayment> AddAsync(CartPayment cartPayment)
    {
        CartPayment addedCartPayment = await _cartPaymentRepository.AddAsync(cartPayment);

        return addedCartPayment;
    }

    public async Task<CartPayment> UpdateAsync(CartPayment cartPayment)
    {
        CartPayment updatedCartPayment = await _cartPaymentRepository.UpdateAsync(cartPayment);

        return updatedCartPayment;
    }

    public async Task<CartPayment> DeleteAsync(CartPayment cartPayment, bool permanent = false)
    {
        CartPayment deletedCartPayment = await _cartPaymentRepository.DeleteAsync(cartPayment);

        return deletedCartPayment;
    }
}
