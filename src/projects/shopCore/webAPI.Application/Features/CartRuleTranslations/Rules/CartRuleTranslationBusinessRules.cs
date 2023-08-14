using Application.Features.CartRuleTranslations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.CartRuleTranslations.Rules;

public class CartRuleTranslationBusinessRules : BaseBusinessRules
{
    private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;

    public CartRuleTranslationBusinessRules(ICartRuleTranslationRepository cartRuleTranslationRepository)
    {
        _cartRuleTranslationRepository = cartRuleTranslationRepository;
    }

    public Task CartRuleTranslationShouldExistWhenSelected(CartRuleTranslation? cartRuleTranslation)
    {
        if (cartRuleTranslation == null)
            throw new BusinessException(CartRuleTranslationsBusinessMessages.CartRuleTranslationNotExists);
        return Task.CompletedTask;
    }

    public async Task CartRuleTranslationIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        CartRuleTranslation? cartRuleTranslation = await _cartRuleTranslationRepository.GetAsync(
            predicate: crt => crt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CartRuleTranslationShouldExistWhenSelected(cartRuleTranslation);
    }
}