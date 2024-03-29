using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductAppointmentSlotRepository : EfRepositoryBase<BookingProductAppointmentSlot, uint, BaseDbContext>, IBookingProductAppointmentSlotRepository
{
    public BookingProductAppointmentSlotRepository(BaseDbContext context) : base(context)
    {
    }
}