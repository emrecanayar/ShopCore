using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductEventTicketRepository : EfRepositoryBase<BookingProductEventTicket, uint, BaseDbContext>, IBookingProductEventTicketRepository
{
    public BookingProductEventTicketRepository(BaseDbContext context) : base(context)
    {
    }
}