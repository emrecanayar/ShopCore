using Application.Features.CartRuleChannels.Constants;
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
using static Application.Features.CartRuleChannels.Constants.CartRuleChannelsOperationClaims;

namespace Application.Features.CartRuleChannels.Queries.GetList;

public class GetListCartRuleChannelQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleChannelListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleChannelQueryHandler : IRequestHandler<GetListCartRuleChannelQuery, CustomResponseDto<GetListResponse<GetListCartRuleChannelListItemDto>>>
    {
        private readonly ICartRuleChannelRepository _cartRuleChannelRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleChannelQueryHandler(ICartRuleChannelRepository cartRuleChannelRepository, IMapper mapper)
        {
            _cartRuleChannelRepository = cartRuleChannelRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleChannelListItemDto>>> Handle(GetListCartRuleChannelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleChannel> cartRuleChannels = await _cartRuleChannelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleChannelListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleChannelListItemDto>>(cartRuleChannels);
             return CustomResponseDto<GetListResponse<GetListCartRuleChannelListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}