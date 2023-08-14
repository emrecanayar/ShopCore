using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICartPaymentRepository : IAsyncRepository<CartPayment, uint>, IRepository<CartPayment, uint>
{
}