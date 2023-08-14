using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductEventTicketRepository : IAsyncRepository<BookingProductEventTicket, uint>, IRepository<BookingProductEventTicket, uint>
{
}