using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartPayments;

public interface ICartPaymentsService
{
    Task<CartPayment?> GetAsync(
        Expression<Func<CartPayment, bool>> predicate,
        Func<IQueryable<CartPayment>, IIncludableQueryable<CartPayment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CartPayment>?> GetListAsync(
        Expression<Func<CartPayment, bool>>? predicate = null,
        Func<IQueryable<CartPayment>, IOrderedQueryable<CartPayment>>? orderBy = null,
        Func<IQueryable<CartPayment>, IIncludableQueryable<CartPayment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CartPayment> AddAsync(CartPayment cartPayment);
    Task<CartPayment> UpdateAsync(CartPayment cartPayment);
    Task<CartPayment> DeleteAsync(CartPayment cartPayment, bool permanent = false);
}
