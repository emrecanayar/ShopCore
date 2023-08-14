using Application.Features.AttributeFamilies.Constants;
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
using static Application.Features.AttributeFamilies.Constants.AttributeFamiliesOperationClaims;

namespace Application.Features.AttributeFamilies.Queries.GetList;

public class GetListAttributeFamilyQuery : IRequest<CustomResponseDto<GetListResponse<GetListAttributeFamilyListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAttributeFamilyQueryHandler : IRequestHandler<GetListAttributeFamilyQuery, CustomResponseDto<GetListResponse<GetListAttributeFamilyListItemDto>>>
    {
        private readonly IAttributeFamilyRepository _attributeFamilyRepository;
        private readonly IMapper _mapper;

        public GetListAttributeFamilyQueryHandler(IAttributeFamilyRepository attributeFamilyRepository, IMapper mapper)
        {
            _attributeFamilyRepository = attributeFamilyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAttributeFamilyListItemDto>>> Handle(GetListAttributeFamilyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AttributeFamily> attributeFamilies = await _attributeFamilyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttributeFamilyListItemDto> response = _mapper.Map<GetListResponse<GetListAttributeFamilyListItemDto>>(attributeFamilies);
             return CustomResponseDto<GetListResponse<GetListAttributeFamilyListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}