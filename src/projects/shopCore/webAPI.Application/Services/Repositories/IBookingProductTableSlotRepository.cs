using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductTableSlotRepository : IAsyncRepository<BookingProductTableSlot, uint>, IRepository<BookingProductTableSlot, uint>
{
}