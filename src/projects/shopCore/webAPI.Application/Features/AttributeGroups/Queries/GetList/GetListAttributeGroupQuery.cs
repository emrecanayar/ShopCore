using Application.Features.AttributeGroups.Constants;
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
using static Application.Features.AttributeGroups.Constants.AttributeGroupsOperationClaims;

namespace Application.Features.AttributeGroups.Queries.GetList;

public class GetListAttributeGroupQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeGroupListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeGroupQueryHandler : IRequestHandler<GetListAttributeGroupQuery, CustomResponseDto<GetListResponse<GetListAttributeGroupListItemDto>>>
    {
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        private readonly IMapper _mapper;

        public GetListAttributeGroupQueryHandler(IAttributeGroupRepository attributeGroupRepository, IMapper mapper)
        {
            _attributeGroupRepository = attributeGroupRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeGroupListItemDto>>> Handle(GetListAttributeGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AttributeGroup> attributeGroups = await _attributeGroupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeGroupListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeGroupListItemDto>>(attributeGroups);
             return CustomResponseDto<GetListResponse<GetListAttributeGroupListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}