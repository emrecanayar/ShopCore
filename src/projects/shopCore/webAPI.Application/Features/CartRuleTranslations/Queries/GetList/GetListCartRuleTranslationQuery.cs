using Application.Features.CartRuleTranslations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CartRuleTranslations.Constants.CartRuleTranslationsOperationClaims;

namespace Application.Features.CartRuleTranslations.Queries.GetList;

public class GetListCartRuleTranslationQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleTranslationListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleTranslationQueryHandler : IRequestHandler<GetListCartRuleTranslationQuery, CustomResponseDto<GetListResponse<GetListCartRuleTranslationListItemDto>>>
    {
        private readonly ICartRuleTranslationRepository _cartRuleTranslationRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleTranslationQueryHandler(ICartRuleTranslationRepository cartRuleTranslationRepository, IMapper mapper)
        {
            _cartRuleTranslationRepository = cartRuleTranslationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleTranslationListItemDto>>> Handle(GetListCartRuleTranslationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleTranslation> cartRuleTranslations = await _cartRuleTranslationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleTranslationListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleTranslationListItemDto>>(cartRuleTranslations);
             return CustomResponseDto<GetListResponse<GetListCartRuleTranslationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}