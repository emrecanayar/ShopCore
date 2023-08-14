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

namespace Application.Features.AttributeOptionTranslations.Queries.GetById;

public class GetByIdAttributeOptionTranslationQuery : IRequest<CustomResponseDto<GetByIdAttributeOptionTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeOptionTranslationQueryHandler : IRequestHandler<GetByIdAttributeOptionTranslationQuery, CustomResponseDto<GetByIdAttributeOptionTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionTranslationRepository _attributeOptionTranslationRepository;
        private readonly AttributeOptionTranslationBusinessRules _attributeOptionTranslationBusinessRules;

        public GetByIdAttributeOptionTranslationQueryHandler(IMapper mapper, IAttributeOptionTranslationRepository attributeOptionTranslationRepository, AttributeOptionTranslationBusinessRules attributeOptionTranslationBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionTranslationRepository = attributeOptionTranslationRepository;
            _attributeOptionTranslationBusinessRules = attributeOptionTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeOptionTranslationResponse>> Handle(GetByIdAttributeOptionTranslationQuery request, CancellationToken cancellationToken)
        {
            AttributeOptionTranslation? attributeOptionTranslation = await _attributeOptionTranslationRepository.GetAsync(predicate: aot => aot.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionTranslationBusinessRules.AttributeOptionTranslationShouldExistWhenSelected(attributeOptionTranslation);

            GetByIdAttributeOptionTranslationResponse response = _mapper.Map<GetByIdAttributeOptionTranslationResponse>(attributeOptionTranslation);

          return CustomResponseDto<GetByIdAttributeOptionTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}