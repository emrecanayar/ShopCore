using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductDefaultSlotRepository : EfRepositoryBase<BookingProductDefaultSlot, uint, BaseDbContext>, IBookingProductDefaultSlotRepository
{
    public BookingProductDefaultSlotRepository(BaseDbContext context) : base(context)
    {
    }
}