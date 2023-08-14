using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductRentalSlotRepository : IAsyncRepository<BookingProductRentalSlot, uint>, IRepository<BookingProductRentalSlot, uint>
{
}