using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingRepository : EfRepositoryBase<Booking, uint, BaseDbContext>, IBookingRepository
{
    public BookingRepository(BaseDbContext context) : base(context)
    {
    }
}