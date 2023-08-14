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

namespace Application.Features.CategoryTranslations.Commands.Create;

public class CreateCategoryTranslationCommand : IRequest<CustomResponseDto<CreatedCategoryTranslationResponse>>, ISecuredRequest
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
    public uint CategoryId { get; set; }
    public string Locale { get; set; }
    public uint? LocaleId { get; set; }
    public string UrlPath { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryTranslationsOperationClaims.Create };

    public class CreateCategoryTranslationCommandHandler : IRequestHandler<CreateCategoryTranslationCommand, CustomResponseDto<CreatedCategoryTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        private readonly CategoryTranslationBusinessRules _categoryTranslationBusinessRules;

        public CreateCategoryTranslationCommandHandler(IMapper mapper, ICategoryTranslationRepository categoryTranslationRepository,
                                         CategoryTranslationBusinessRules categoryTranslationBusinessRules)
        {
            _mapper = mapper;
            _categoryTranslationRepository = categoryTranslationRepository;
            _categoryTranslationBusinessRules = categoryTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCategoryTranslationResponse>> Handle(CreateCategoryTranslationCommand request, CancellationToken cancellationToken)
        {
            CategoryTranslation categoryTranslation = _mapper.Map<CategoryTranslation>(request);

            await _categoryTranslationRepository.AddAsync(categoryTranslation);

            CreatedCategoryTranslationResponse response = _mapper.Map<CreatedCategoryTranslationResponse>(categoryTranslation);
         return CustomResponseDto<CreatedCategoryTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}