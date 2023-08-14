using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using static Application.Features.Attributes.Constants.AttributesOperationClaims;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Features.Attributes.Queries.GetList;

public class GetListAttributeQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeQueryHandler : IRequestHandler<GetListAttributeQuery, CustomResponseDto<GetListResponse<GetListAttributeListItemDto>>>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetListAttributeQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeListItemDto>>> Handle(GetListAttributeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Attribute> attributes = await _attributeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeListItemDto>>(attributes);
            return CustomResponseDto<GetListResponse<GetListAttributeListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}