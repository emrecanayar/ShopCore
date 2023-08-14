using Application.Features.AttributeFamilies.Constants;
using Application.Features.AttributeFamilies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeFamilies.Constants.AttributeFamiliesOperationClaims;

namespace Application.Features.AttributeFamilies.Queries.GetById;

public class GetByIdAttributeFamilyQuery : IRequest<CustomResponseDto<GetByIdAttributeFamilyResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeFamilyQueryHandler : IRequestHandler<GetByIdAttributeFamilyQuery, CustomResponseDto<GetByIdAttributeFamilyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeFamilyRepository _attributeFamilyRepository;
        private readonly AttributeFamilyBusinessRules _attributeFamilyBusinessRules;

        public GetByIdAttributeFamilyQueryHandler(IMapper mapper, IAttributeFamilyRepository attributeFamilyRepository, AttributeFamilyBusinessRules attributeFamilyBusinessRules)
        {
            _mapper = mapper;
            _attributeFamilyRepository = attributeFamilyRepository;
            _attributeFamilyBusinessRules = attributeFamilyBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeFamilyResponse>> Handle(GetByIdAttributeFamilyQuery request, CancellationToken cancellationToken)
        {
            AttributeFamily? attributeFamily = await _attributeFamilyRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeFamilyBusinessRules.AttributeFamilyShouldExistWhenSelected(attributeFamily);

            GetByIdAttributeFamilyResponse response = _mapper.Map<GetByIdAttributeFamilyResponse>(attributeFamily);

          return CustomResponseDto<GetByIdAttributeFamilyResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}