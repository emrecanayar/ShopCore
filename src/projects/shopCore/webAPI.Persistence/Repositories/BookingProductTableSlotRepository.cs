using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductTableSlotRepository : EfRepositoryBase<BookingProductTableSlot, uint, BaseDbContext>, IBookingProductTableSlotRepository
{
    public BookingProductTableSlotRepository(BaseDbContext context) : base(context)
    {
    }
}