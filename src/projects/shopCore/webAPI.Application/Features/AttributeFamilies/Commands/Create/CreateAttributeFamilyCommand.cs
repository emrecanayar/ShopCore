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

namespace Application.Features.AttributeFamilies.Commands.Create;

public class CreateAttributeFamilyCommand : IRequest<CustomResponseDto<CreatedAttributeFamilyResponse>>, ISecuredRequest
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool? IsUserDefined { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeFamiliesOperationClaims.Create };

    public class CreateAttributeFamilyCommandHandler : IRequestHandler<CreateAttributeFamilyCommand, CustomResponseDto<CreatedAttributeFamilyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeFamilyRepository _attributeFamilyRepository;
        private readonly AttributeFamilyBusinessRules _attributeFamilyBusinessRules;

        public CreateAttributeFamilyCommandHandler(IMapper mapper, IAttributeFamilyRepository attributeFamilyRepository,
                                         AttributeFamilyBusinessRules attributeFamilyBusinessRules)
        {
            _mapper = mapper;
            _attributeFamilyRepository = attributeFamilyRepository;
            _attributeFamilyBusinessRules = attributeFamilyBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeFamilyResponse>> Handle(CreateAttributeFamilyCommand request, CancellationToken cancellationToken)
        {
            AttributeFamily attributeFamily = _mapper.Map<AttributeFamily>(request);

            await _attributeFamilyRepository.AddAsync(attributeFamily);

            CreatedAttributeFamilyResponse response = _mapper.Map<CreatedAttributeFamilyResponse>(attributeFamily);
         return CustomResponseDto<CreatedAttributeFamilyResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}