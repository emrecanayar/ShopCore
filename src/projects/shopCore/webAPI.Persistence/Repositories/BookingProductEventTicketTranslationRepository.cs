using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class BookingProductEventTicketTranslationRepository : EfRepositoryBase<BookingProductEventTicketTranslation, uint, BaseDbContext>, IBookingProductEventTicketTranslationRepository
{
    public BookingProductEventTicketTranslationRepository(BaseDbContext context) : base(context)
    {
    }
}