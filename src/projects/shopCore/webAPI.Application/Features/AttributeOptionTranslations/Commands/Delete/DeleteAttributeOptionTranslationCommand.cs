using Application.Features.AttributeOptionTranslations.Constants;
using Application.Features.AttributeOptionTranslations.Constants;
using Application.Features.AttributeOptionTranslations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeOptionTranslations.Constants.AttributeOptionTranslationsOperationClaims;

namespace Application.Features.AttributeOptionTranslations.Commands.Delete;

public class DeleteAttributeOptionTranslationCommand : IRequest<CustomResponseDto<DeletedAttributeOptionTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionTranslationsOperationClaims.Delete };

    public class DeleteAttributeOptionTranslationCommandHandler : IRequestHandler<DeleteAttributeOptionTranslationCommand, CustomResponseDto<DeletedAttributeOptionTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
        private readonly AttributeOptionTranslationBusinessRules _attributeOptionTranslationBusinessRules;

        public DeleteAttributeOptionTranslationCommandHandler(IMapper mapper, IAttributeOptionTranslationRepository attributeOptionTranslationRepository,
                                         AttributeOptionTranslationBusinessRules attributeOptionTranslationBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
            _attributeOptionTranslationBusinessRules = attributeOptionTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeOptionTranslationResponse>> Handle(DeleteAttributeOptionTranslationCommand request, CancellationToken cancellationToken)
        {
            AttributeOptionTranslation? attributeOptionTranslation = await _attributeOptionTranslationRepository.GetAsync(predicate: aot => aot.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionTranslationBusinessRules.AttributeOptionTranslationShouldExistWhenSelected(attributeOptionTranslation);

            await _attributeOptionTranslationRepository.DeleteAsync(attributeOptionTranslation!);

            DeletedAttributeOptionTranslationResponse response = _mapper.Map<DeletedAttributeOptionTranslationResponse>(attributeOptionTranslation);

             return CustomResponseDto<DeletedAttributeOptionTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}