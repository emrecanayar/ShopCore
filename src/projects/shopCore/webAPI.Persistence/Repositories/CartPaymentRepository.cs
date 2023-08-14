using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CartPaymentRepository : EfRepositoryBase<CartPayment, uint, BaseDbContext>, ICartPaymentRepository
{
    public CartPaymentRepository(BaseDbContext context) : base(context)
    {
    }
}