using Application.Features.CatalogRuleCustomerGroups.Constants;
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
using static Application.Features.CatalogRuleCustomerGroups.Constants.CatalogRuleCustomerGroupsOperationClaims;

namespace Application.Features.CatalogRuleCustomerGroups.Queries.GetList;

public class GetListCatalogRuleCustomerGroupQuery : IRequest<CustomResponseDto<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCatalogRuleCustomerGroupQueryHandler : IRequestHandler<GetListCatalogRuleCustomerGroupQuery, CustomResponseDto<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>>
    {
        private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
        private readonly IMapper _mapper;

        public GetListCatalogRuleCustomerGroupQueryHandler(ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository, IMapper mapper)
        {
            _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>> Handle(GetListCatalogRuleCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogRuleCustomerGroup> catalogRuleCustomerGroups = await _catalogRuleCustomerGroupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogRuleCustomerGroupListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>(catalogRuleCustomerGroups);
             return CustomResponseDto<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}