using Application.Features.CategoryTranslations.Constants;
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
using static Application.Features.CategoryTranslations.Constants.CategoryTranslationsOperationClaims;

namespace Application.Features.CategoryTranslations.Queries.GetList;

public class GetListCategoryTranslationQuery : IRequest<CustomResponseDto<GetListResponse<GetListCategoryTranslationListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCategoryTranslationQueryHandler : IRequestHandler<GetListCategoryTranslationQuery, CustomResponseDto<GetListResponse<GetListCategoryTranslationListItemDto>>>
    {
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        private readonly IMapper _mapper;

        public GetListCategoryTranslationQueryHandler(ICategoryTranslationRepository categoryTranslationRepository, IMapper mapper)
        {
            _categoryTranslationRepository = categoryTranslationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCategoryTranslationListItemDto>>> Handle(GetListCategoryTranslationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryTranslation> categoryTranslations = await _categoryTranslationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryTranslationListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryTranslationListItemDto>>(categoryTranslations);
             return CustomResponseDto<GetListResponse<GetListCategoryTranslationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}