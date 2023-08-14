using Application.Features.AttributeGroupMappings.Constants;
using Application.Features.AttributeGroupMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeGroupMappings.Constants.AttributeGroupMappingsOperationClaims;

namespace Application.Features.AttributeGroupMappings.Commands.Create;

public class CreateAttributeGroupMappingCommand : IRequest<CustomResponseDto<CreatedAttributeGroupMappingResponse>>, ISecuredRequest
{
    public uint AttributeId { get; set; }
    public uint AttributeGroupId { get; set; }
    public int? Position { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupMappingsOperationClaims.Create };

    public class CreateAttributeGroupMappingCommandHandler : IRequestHandler<CreateAttributeGroupMappingCommand, CustomResponseDto<CreatedAttributeGroupMappingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
        private readonly AttributeGroupMappingBusinessRules _attributeGroupMappingBusinessRules;

        public CreateAttributeGroupMappingCommandHandler(IMapper mapper, IAttributeGroupMappingRepository attributeGroupMappingRepository,
                                         AttributeGroupMappingBusinessRules attributeGroupMappingBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupMappingRepository = attributeGroupMappingRepository;
            _attributeGroupMappingBusinessRules = attributeGroupMappingBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeGroupMappingResponse>> Handle(CreateAttributeGroupMappingCommand request, CancellationToken cancellationToken)
        {
            AttributeGroupMapping attributeGroupMapping = _mapper.Map<AttributeGroupMapping>(request);

            await _attributeGroupMappingRepository.AddAsync(attributeGroupMapping);

            CreatedAttributeGroupMappingResponse response = _mapper.Map<CreatedAttributeGroupMappingResponse>(attributeGroupMapping);
         return CustomResponseDto<CreatedAttributeGroupMappingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}