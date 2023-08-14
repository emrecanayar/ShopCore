using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductAppointmentSlotRepository : IAsyncRepository<BookingProductAppointmentSlot, uint>, IRepository<BookingProductAppointmentSlot, uint>
{
}