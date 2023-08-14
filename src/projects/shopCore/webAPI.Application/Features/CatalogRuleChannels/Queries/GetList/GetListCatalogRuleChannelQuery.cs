using Application.Features.CatalogRuleChannels.Constants;
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
using static Application.Features.CatalogRuleChannels.Constants.CatalogRuleChannelsOperationClaims;

namespace Application.Features.CatalogRuleChannels.Queries.GetList;

public class GetListCatalogRuleChannelQuery : IRequest<CustomResponseDto<GetListResponse<GetListCatalogRuleChannelListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCatalogRuleChannelQueryHandler : IRequestHandler<GetListCatalogRuleChannelQuery, CustomResponseDto<GetListResponse<GetListCatalogRuleChannelListItemDto>>>
    {
        private readonly ICatalogRuleChannelRepository _catalogRuleChannelRepository;
        private readonly IMapper _mapper;

        public GetListCatalogRuleChannelQueryHandler(ICatalogRuleChannelRepository catalogRuleChannelRepository, IMapper mapper)
        {
            _catalogRuleChannelRepository = catalogRuleChannelRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCatalogRuleChannelListItemDto>>> Handle(GetListCatalogRuleChannelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogRuleChannel> catalogRuleChannels = await _catalogRuleChannelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogRuleChannelListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogRuleChannelListItemDto>>(catalogRuleChannels);
             return CustomResponseDto<GetListResponse<GetListCatalogRuleChannelListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}