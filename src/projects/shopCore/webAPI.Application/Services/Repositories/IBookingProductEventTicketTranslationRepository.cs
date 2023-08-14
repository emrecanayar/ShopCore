using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBookingProductEventTicketTranslationRepository : IAsyncRepository<BookingProductEventTicketTranslation, uint>, IRepository<BookingProductEventTicketTranslation, uint>
{
}