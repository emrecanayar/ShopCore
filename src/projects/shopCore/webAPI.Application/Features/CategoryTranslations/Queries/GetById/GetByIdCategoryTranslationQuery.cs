using Application.Features.CategoryTranslations.Constants;
using Application.Features.CategoryTranslations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CategoryTranslations.Constants.CategoryTranslationsOperationClaims;

namespace Application.Features.CategoryTranslations.Queries.GetById;

public class GetByIdCategoryTranslationQuery : IRequest<CustomResponseDto<GetByIdCategoryTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCategoryTranslationQueryHandler : IRequestHandler<GetByIdCategoryTranslationQuery, CustomResponseDto<GetByIdCategoryTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        private readonly CategoryTranslationBusinessRules _categoryTranslationBusinessRules;

        public GetByIdCategoryTranslationQueryHandler(IMapper mapper, ICategoryTranslationRepository categoryTranslationRepository, CategoryTranslationBusinessRules categoryTranslationBusinessRules)
        {
            _mapper = mapper;
            _categoryTranslationRepository = categoryTranslationRepository;
            _categoryTranslationBusinessRules = categoryTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCategoryTranslationResponse>> Handle(GetByIdCategoryTranslationQuery request, CancellationToken cancellationToken)
        {
            CategoryTranslation? categoryTranslation = await _categoryTranslationRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTranslationBusinessRules.CategoryTranslationShouldExistWhenSelected(categoryTranslation);

            GetByIdCategoryTranslationResponse response = _mapper.Map<GetByIdCategoryTranslationResponse>(categoryTranslation);

          return CustomResponseDto<GetByIdCategoryTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}