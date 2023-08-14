using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAttributeOptionTranslationRepository : IAsyncRepository<AttributeOptionTranslation, uint>, IRepository<AttributeOptionTranslation, uint>
{
}