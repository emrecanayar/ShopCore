using Application.Features.CategoryFilterableAttributes.Constants;
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
using static Application.Features.CategoryFilterableAttributes.Constants.CategoryFilterableAttributesOperationClaims;

namespace Application.Features.CategoryFilterableAttributes.Queries.GetList;

public class GetListCategoryFilterableAttributeQuery : IRequest<CustomResponseDto<GetListResponse<GetListCategoryFilterableAttributeListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCategoryFilterableAttributeQueryHandler : IRequestHandler<GetListCategoryFilterableAttributeQuery, CustomResponseDto<GetListResponse<GetListCategoryFilterableAttributeListItemDto>>>
    {
        private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
        private readonly IMapper _mapper;

        public GetListCategoryFilterableAttributeQueryHandler(ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository, IMapper mapper)
        {
            _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCategoryFilterableAttributeListItemDto>>> Handle(GetListCategoryFilterableAttributeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryFilterableAttribute> categoryFilterableAttributes = await _categoryFilterableAttributeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryFilterableAttributeListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryFilterableAttributeListItemDto>>(categoryFilterableAttributes);
             return CustomResponseDto<GetListResponse<GetListCategoryFilterableAttributeListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}