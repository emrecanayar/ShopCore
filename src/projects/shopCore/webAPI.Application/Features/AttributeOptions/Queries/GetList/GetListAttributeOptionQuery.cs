using Application.Features.AttributeOptions.Constants;
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
using static Application.Features.AttributeOptions.Constants.AttributeOptionsOperationClaims;

namespace Application.Features.AttributeOptions.Queries.GetList;

public class GetListAttributeOptionQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeOptionListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeOptionQueryHandler : IRequestHandler<GetListAttributeOptionQuery, CustomResponseDto<GetListResponse<GetListAttributeOptionListItemDto>>>
    {
        private readonly IAttributeOptionRepository _attributeOptionRepository;
        private readonly IMapper _mapper;

        public GetListAttributeOptionQueryHandler(IAttributeOptionRepository attributeOptionRepository, IMapper mapper)
        {
            _attributeOptionRepository = attributeOptionRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeOptionListItemDto>>> Handle(GetListAttributeOptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AttributeOption> attributeOptions = await _attributeOptionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeOptionListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeOptionListItemDto>>(attributeOptions);
             return CustomResponseDto<GetListResponse<GetListAttributeOptionListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}