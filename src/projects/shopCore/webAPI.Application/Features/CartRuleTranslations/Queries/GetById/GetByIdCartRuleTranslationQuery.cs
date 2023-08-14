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

namespace Application.Features.CartRuleTranslations.Queries.GetById;

public class GetByIdCartRuleTranslationQuery : IRequest<CustomResponseDto<GetByIdCartRuleTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleTranslationQueryHandler : IRequestHandler<GetByIdCartRuleTranslationQuery, CustomResponseDto<GetByIdCartRuleTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
        private readonly CartRuleTranslationBusinessRules _cartRuleTranslationBusinessRules;

        public GetByIdCartRuleTranslationQueryHandler(IMapper mapper, ICartRuleTranslationRepository cartRuleTranslationRepository, CartRuleTranslationBusinessRules cartRuleTranslationBusinessRules)
        {
            _mapper = mapper;
            _cartRuleTranslationRepository = cartRuleTranslationRepository;
            _cartRuleTranslationBusinessRules = cartRuleTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleTranslationResponse>> Handle(GetByIdCartRuleTranslationQuery request, CancellationToken cancellationToken)
        {
            CartRuleTranslation? cartRuleTranslation = await _cartRuleTranslationRepository.GetAsync(predicate: crt => crt.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleTranslationBusinessRules.CartRuleTranslationShouldExistWhenSelected(cartRuleTranslation);

            GetByIdCartRuleTranslationResponse response = _mapper.Map<GetByIdCartRuleTranslationResponse>(cartRuleTranslation);

          return CustomResponseDto<GetByIdCartRuleTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}