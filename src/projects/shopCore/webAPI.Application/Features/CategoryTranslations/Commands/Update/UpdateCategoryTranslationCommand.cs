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

namespace Application.Features.CategoryTranslations.Commands.Update;

public class UpdateCategoryTranslationCommand : IRequest<CustomResponseDto<UpdatedCategoryTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, CategoryTranslationsOperationClaims.Update };

    public class UpdateCategoryTranslationCommandHandler : IRequestHandler<UpdateCategoryTranslationCommand, CustomResponseDto<UpdatedCategoryTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        private readonly CategoryTranslationBusinessRules _categoryTranslationBusinessRules;

        public UpdateCategoryTranslationCommandHandler(IMapper mapper, ICategoryTranslationRepository categoryTranslationRepository,
                                         CategoryTranslationBusinessRules categoryTranslationBusinessRules)
        {
            _mapper = mapper;
            _categoryTranslationRepository = categoryTranslationRepository;
            _categoryTranslationBusinessRules = categoryTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCategoryTranslationResponse>> Handle(UpdateCategoryTranslationCommand request, CancellationToken cancellationToken)
        {
            CategoryTranslation? categoryTranslation = await _categoryTranslationRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTranslationBusinessRules.CategoryTranslationShouldExistWhenSelected(categoryTranslation);
            categoryTranslation = _mapper.Map(request, categoryTranslation);

            await _categoryTranslationRepository.UpdateAsync(categoryTranslation!);

            UpdatedCategoryTranslationResponse response = _mapper.Map<UpdatedCategoryTranslationResponse>(categoryTranslation);

          return CustomResponseDto<UpdatedCategoryTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}