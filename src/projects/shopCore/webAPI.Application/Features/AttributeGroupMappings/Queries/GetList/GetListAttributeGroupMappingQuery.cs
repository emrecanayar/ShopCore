using Application.Features.AttributeGroupMappings.Constants;
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
using static Application.Features.AttributeGroupMappings.Constants.AttributeGroupMappingsOperationClaims;

namespace Application.Features.AttributeGroupMappings.Queries.GetList;

public class GetListAttributeGroupMappingQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeGroupMappingListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeGroupMappingQueryHandler : IRequestHandler<GetListAttributeGroupMappingQuery, CustomResponseDto<GetListResponse<GetListAttributeGroupMappingListItemDto>>>
    {
        private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
        private readonly IMapper _mapper;

        public GetListAttributeGroupMappingQueryHandler(IAttributeGroupMappingRepository attributeGroupMappingRepository, IMapper mapper)
        {
            _attributeGroupMappingRepository = attributeGroupMappingRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeGroupMappingListItemDto>>> Handle(GetListAttributeGroupMappingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AttributeGroupMapping> attributeGroupMappings = await _attributeGroupMappingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeGroupMappingListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeGroupMappingListItemDto>>(attributeGroupMappings);
             return CustomResponseDto<GetListResponse<GetListAttributeGroupMappingListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}