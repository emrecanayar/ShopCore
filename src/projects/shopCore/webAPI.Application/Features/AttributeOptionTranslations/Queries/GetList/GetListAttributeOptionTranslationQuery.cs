using Application.Features.AttributeOptionTranslations.Constants;
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
using static Application.Features.AttributeOptionTranslations.Constants.AttributeOptionTranslationsOperationClaims;

namespace Application.Features.AttributeOptionTranslations.Queries.GetList;

public class GetListAttributeOptionTranslationQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeOptionTranslationListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeOptionTranslationQueryHandler : IRequestHandler<GetListAttributeOptionTranslationQuery, CustomResponseDto<GetListResponse<GetListAttributeOptionTranslationListItemDto>>>
    {
        private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
        private readonly IMapper _mapper;

        public GetListAttributeOptionTranslationQueryHandler(IAttributeOptionTranslationRepository attributeOptionTranslationRepository, IMapper mapper)
        {
            _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeOptionTranslationListItemDto>>> Handle(GetListAttributeOptionTranslationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AttributeOptionTranslation> attributeOptionTranslations = await _attributeOptionTranslationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeOptionTranslationListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeOptionTranslationListItemDto>>(attributeOptionTranslations);
             return CustomResponseDto<GetListResponse<GetListAttributeOptionTranslationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}