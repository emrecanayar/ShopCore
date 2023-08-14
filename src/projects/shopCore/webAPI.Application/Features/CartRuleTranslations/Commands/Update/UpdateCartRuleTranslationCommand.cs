using Application.Features.CartRuleTranslations.Constants;
using Application.Features.CartRuleTranslations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleTranslations.Constants.CartRuleTranslationsOperationClaims;

namespace Application.Features.CartRuleTranslations.Commands.Update;

public class UpdateCartRuleTranslationCommand : IRequest<CustomResponseDto<UpdatedCartRuleTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint CartRuleId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleTranslationsOperationClaims.Update };

    public class UpdateCartRuleTranslationCommandHandler : IRequestHandler<UpdateCartRuleTranslationCommand, CustomResponseDto<UpdatedCartRuleTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
        private readonly CartRuleTranslationBusinessRules _cartRuleTranslationBusinessRules;

        public UpdateCartRuleTranslationCommandHandler(IMapper mapper, ICartRuleTranslationRepository cartRuleTranslationRepository,
                                         CartRuleTranslationBusinessRules cartRuleTranslationBusinessRules)
        {
            _mapper = mapper;
            _cartRuleTranslationRepository = cartRuleTranslationRepository;
            _cartRuleTranslationBusinessRules = cartRuleTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleTranslationResponse>> Handle(UpdateCartRuleTranslationCommand request, CancellationToken cancellationToken)
        {
            CartRuleTranslation? cartRuleTranslation = await _cartRuleTranslationRepository.GetAsync(predicate: crt => crt.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleTranslationBusinessRules.CartRuleTranslationShouldExistWhenSelected(cartRuleTranslation);
            cartRuleTranslation = _mapper.Map(request, cartRuleTranslation);

            await _cartRuleTranslationRepository.UpdateAsync(cartRuleTranslation!);

            UpdatedCartRuleTranslationResponse response = _mapper.Map<UpdatedCartRuleTranslationResponse>(cartRuleTranslation);

          return CustomResponseDto<UpdatedCartRuleTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}