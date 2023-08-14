using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductRentalSlotRepository : EfRepositoryBase<BookingProductRentalSlot, uint, BaseDbContext>, IBookingProductRentalSlotRepository
{
    public BookingProductRentalSlotRepository(BaseDbContext context) : base(context)
    {
    }
}