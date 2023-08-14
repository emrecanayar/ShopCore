using Application.Features.CartRuleTranslations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CartRuleTranslations;

public class CartRuleTranslationsManager : ICartRuleTranslationsService
{
    private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
    private readonly CartRuleTranslationBusinessRules _cartRuleTranslationBusinessRules;

    public CartRuleTranslationsManager(ICartRuleTranslationRepository cartRuleTranslationRepository, CartRuleTranslationBusinessRules cartRuleTranslationBusinessRules)
    {
        _cartRuleTranslationRepository = cartRuleTranslationRepository;
        _cartRuleTranslationBusinessRules = cartRuleTranslationBusinessRules;
    }

    public async Task<CartRuleTranslation?> GetAsync(
        Expression<Func<CartRuleTranslation, bool>> predicate,
        Func<IQueryable<CartRuleTranslation>, IIncludableQueryable<CartRuleTranslation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CartRuleTranslation? cartRuleTranslation = await _cartRuleTranslationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cartRuleTranslation;
    }

    public async Task<IPaginate<CartRuleTranslation>?> GetListAsync(
        Expression<Func<CartRuleTranslation, bool>>? predicate = null,
        Func<IQueryable<CartRuleTranslation>, IOrderedQueryable<CartRuleTranslation>>? orderBy = null,
        Func<IQueryable<CartRuleTranslation>, IIncludableQueryable<CartRuleTranslation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CartRuleTranslation> cartRuleTranslationList = await _cartRuleTranslationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cartRuleTranslationList;
    }

    public async Task<CartRuleTranslation> AddAsync(CartRuleTranslation cartRuleTranslation)
    {
        CartRuleTranslation addedCartRuleTranslation = await _cartRuleTranslationRepository.AddAsync(cartRuleTranslation);

        return addedCartRuleTranslation;
    }

    public async Task<CartRuleTranslation> UpdateAsync(CartRuleTranslation cartRuleTranslation)
    {
        CartRuleTranslation updatedCartRuleTranslation = await _cartRuleTranslationRepository.UpdateAsync(cartRuleTranslation);

        return updatedCartRuleTranslation;
    }

    public async Task<CartRuleTranslation> DeleteAsync(CartRuleTranslation cartRuleTranslation, bool permanent = false)
    {
        CartRuleTranslation deletedCartRuleTranslation = await _cartRuleTranslationRepository.DeleteAsync(cartRuleTranslation);

        return deletedCartRuleTranslation;
    }
}
