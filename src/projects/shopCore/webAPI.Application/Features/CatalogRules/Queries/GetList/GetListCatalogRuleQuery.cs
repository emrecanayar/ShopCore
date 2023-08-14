using Application.Features.CatalogRules.Constants;
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
using static Application.Features.CatalogRules.Constants.CatalogRulesOperationClaims;

namespace Application.Features.CatalogRules.Queries.GetList;

public class GetListCatalogRuleQuery : IRequest<CustomResponseDto<GetListResponse<GetListCatalogRuleListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCatalogRuleQueryHandler : IRequestHandler<GetListCatalogRuleQuery, CustomResponseDto<GetListResponse<GetListCatalogRuleListItemDto>>>
    {
        private readonly ICatalogRuleRepository _catalogRuleRepository;
        private readonly IMapper _mapper;

        public GetListCatalogRuleQueryHandler(ICatalogRuleRepository catalogRuleRepository, IMapper mapper)
        {
            _catalogRuleRepository = catalogRuleRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCatalogRuleListItemDto>>> Handle(GetListCatalogRuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogRule> catalogRules = await _catalogRuleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogRuleListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogRuleListItemDto>>(catalogRules);
             return CustomResponseDto<GetListResponse<GetListCatalogRuleListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}