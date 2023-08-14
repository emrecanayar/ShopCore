using Application.Features.CategoryTranslations.Constants;
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

namespace Application.Features.CategoryTranslations.Commands.Delete;

public class DeleteCategoryTranslationCommand : IRequest<CustomResponseDto<DeletedCategoryTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryTranslationsOperationClaims.Delete };

    public class DeleteCategoryTranslationCommandHandler : IRequestHandler<DeleteCategoryTranslationCommand, CustomResponseDto<DeletedCategoryTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        private readonly CategoryTranslationBusinessRules _categoryTranslationBusinessRules;

        public DeleteCategoryTranslationCommandHandler(IMapper mapper, ICategoryTranslationRepository categoryTranslationRepository,
                                         CategoryTranslationBusinessRules categoryTranslationBusinessRules)
        {
            _mapper = mapper;
            _categoryTranslationRepository = categoryTranslationRepository;
            _categoryTranslationBusinessRules = categoryTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCategoryTranslationResponse>> Handle(DeleteCategoryTranslationCommand request, CancellationToken cancellationToken)
        {
            CategoryTranslation? categoryTranslation = await _categoryTranslationRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTranslationBusinessRules.CategoryTranslationShouldExistWhenSelected(categoryTranslation);

            await _categoryTranslationRepository.DeleteAsync(categoryTranslation!);

            DeletedCategoryTranslationResponse response = _mapper.Map<DeletedCategoryTranslationResponse>(categoryTranslation);

             return CustomResponseDto<DeletedCategoryTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}