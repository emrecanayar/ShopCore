using Application.Features.CartRules.Constants;
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
using static Application.Features.CartRules.Constants.CartRulesOperationClaims;

namespace Application.Features.CartRules.Queries.GetList;

public class GetListCartRuleQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleQueryHandler : IRequestHandler<GetListCartRuleQuery, CustomResponseDto<GetListResponse<GetListCartRuleListItemDto>>>
    {
        private readonly ICartRuleRepository _cartRuleRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleQueryHandler(ICartRuleRepository cartRuleRepository, IMapper mapper)
        {
            _cartRuleRepository = cartRuleRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleListItemDto>>> Handle(GetListCartRuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRule> cartRules = await _cartRuleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleListItemDto>>(cartRules);
             return CustomResponseDto<GetListResponse<GetListCartRuleListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}