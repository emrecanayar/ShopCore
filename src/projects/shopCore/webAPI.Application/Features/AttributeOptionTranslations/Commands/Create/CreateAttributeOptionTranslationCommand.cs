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

namespace Application.Features.AttributeOptionTranslations.Commands.Create;

public class CreateAttributeOptionTranslationCommand : IRequest<CustomResponseDto<CreatedAttributeOptionTranslationResponse>>, ISecuredRequest
{
    public string Locale { get; set; }
    public string? Label { get; set; }
    public uint AttributeOptionId { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionTranslationsOperationClaims.Create };

    public class CreateAttributeOptionTranslationCommandHandler : IRequestHandler<CreateAttributeOptionTranslationCommand, CustomResponseDto<CreatedAttributeOptionTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
        private readonly AttributeOptionTranslationBusinessRules _attributeOptionTranslationBusinessRules;

        public CreateAttributeOptionTranslationCommandHandler(IMapper mapper, IAttributeOptionTranslationRepository attributeOptionTranslationRepository,
                                         AttributeOptionTranslationBusinessRules attributeOptionTranslationBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
            _attributeOptionTranslationBusinessRules = attributeOptionTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeOptionTranslationResponse>> Handle(CreateAttributeOptionTranslationCommand request, CancellationToken cancellationToken)
        {
            AttributeOptionTranslation attributeOptionTranslation = _mapper.Map<AttributeOptionTranslation>(request);

            await _attributeOptionTranslationRepository.AddAsync(attributeOptionTranslation);

            CreatedAttributeOptionTranslationResponse response = _mapper.Map<CreatedAttributeOptionTranslationResponse>(attributeOptionTranslation);
         return CustomResponseDto<CreatedAttributeOptionTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}