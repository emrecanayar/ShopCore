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

namespace Application.Features.AttributeOptionTranslations.Commands.Update;

public class UpdateAttributeOptionTranslationCommand : IRequest<CustomResponseDto<UpdatedAttributeOptionTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint AttributeOptionId { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionTranslationsOperationClaims.Update };

    public class UpdateAttributeOptionTranslationCommandHandler : IRequestHandler<UpdateAttributeOptionTranslationCommand, CustomResponseDto<UpdatedAttributeOptionTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
        private readonly AttributeOptionTranslationBusinessRules _attributeOptionTranslationBusinessRules;

        public UpdateAttributeOptionTranslationCommandHandler(IMapper mapper, IAttributeOptionTranslationRepository attributeOptionTranslationRepository,
                                         AttributeOptionTranslationBusinessRules attributeOptionTranslationBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
            _attributeOptionTranslationBusinessRules = attributeOptionTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeOptionTranslationResponse>> Handle(UpdateAttributeOptionTranslationCommand request, CancellationToken cancellationToken)
        {
            AttributeOptionTranslation? attributeOptionTranslation = await _attributeOptionTranslationRepository.GetAsync(predicate: aot => aot.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionTranslationBusinessRules.AttributeOptionTranslationShouldExistWhenSelected(attributeOptionTranslation);
            attributeOptionTranslation = _mapper.Map(request, attributeOptionTranslation);

            await _attributeOptionTranslationRepository.UpdateAsync(attributeOptionTranslation!);

            UpdatedAttributeOptionTranslationResponse response = _mapper.Map<UpdatedAttributeOptionTranslationResponse>(attributeOptionTranslation);

          return CustomResponseDto<UpdatedAttributeOptionTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}