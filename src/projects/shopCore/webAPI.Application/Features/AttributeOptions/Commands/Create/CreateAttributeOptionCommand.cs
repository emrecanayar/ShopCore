using Application.Features.AttributeOptions.Constants;
using Application.Features.AttributeOptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeOptions.Constants.AttributeOptionsOperationClaims;

namespace Application.Features.AttributeOptions.Commands.Create;

public class CreateAttributeOptionCommand : IRequest<CustomResponseDto<CreatedAttributeOptionResponse>>, ISecuredRequest
{
    public string? AdminName { get; set; }
    public int? SortOrder { get; set; }
    public uint AttributeId { get; set; }
    public string? SwatchValue { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionsOperationClaims.Create };

    public class CreateAttributeOptionCommandHandler : IRequestHandler<CreateAttributeOptionCommand, CustomResponseDto<CreatedAttributeOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionRepository _attributeOptionRepository;
        private readonly AttributeOptionBusinessRules _attributeOptionBusinessRules;

        public CreateAttributeOptionCommandHandler(IMapper mapper, IAttributeOptionRepository attributeOptionRepository,
                                         AttributeOptionBusinessRules attributeOptionBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionRepository = attributeOptionRepository;
            _attributeOptionBusinessRules = attributeOptionBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeOptionResponse>> Handle(CreateAttributeOptionCommand request, CancellationToken cancellationToken)
        {
            AttributeOption attributeOption = _mapper.Map<AttributeOption>(request);

            await _attributeOptionRepository.AddAsync(attributeOption);

            CreatedAttributeOptionResponse response = _mapper.Map<CreatedAttributeOptionResponse>(attributeOption);
         return CustomResponseDto<CreatedAttributeOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}