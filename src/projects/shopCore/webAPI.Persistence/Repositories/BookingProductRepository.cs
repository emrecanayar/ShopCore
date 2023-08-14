using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductRepository : EfRepositoryBase<BookingProduct, uint, BaseDbContext>, IBookingProductRepository
{
    public BookingProductRepository(BaseDbContext context) : base(context)
    {
    }
}