using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductDefaultSlotRepository : IAsyncRepository<BookingProductDefaultSlot, uint>, IRepository<BookingProductDefaultSlot, uint>
{
}