using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingRepository : IAsyncRepository<Booking, uint>, IRepository<Booking, uint>
{
}