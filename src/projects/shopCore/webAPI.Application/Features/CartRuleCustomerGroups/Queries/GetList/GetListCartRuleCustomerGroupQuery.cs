using Application.Features.CartRuleCustomerGroups.Constants;
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
using static Application.Features.CartRuleCustomerGroups.Constants.CartRuleCustomerGroupsOperationClaims;

namespace Application.Features.CartRuleCustomerGroups.Queries.GetList;

public class GetListCartRuleCustomerGroupQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleCustomerGroupListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleCustomerGroupQueryHandler : IRequestHandler<GetListCartRuleCustomerGroupQuery, CustomResponseDto<GetListResponse<GetListCartRuleCustomerGroupListItemDto>>>
    {
        private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleCustomerGroupQueryHandler(ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository, IMapper mapper)
        {
            _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleCustomerGroupListItemDto>>> Handle(GetListCartRuleCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleCustomerGroup> cartRuleCustomerGroups = await _cartRuleCustomerGroupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleCustomerGroupListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleCustomerGroupListItemDto>>(cartRuleCustomerGroups);
             return CustomResponseDto<GetListResponse<GetListCartRuleCustomerGroupListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}