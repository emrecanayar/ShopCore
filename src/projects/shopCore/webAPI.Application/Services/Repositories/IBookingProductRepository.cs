using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductRepository : IAsyncRepository<BookingProduct, uint>, IRepository<BookingProduct, uint>
{
}