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

namespace Application.Features.AttributeGroupMappings.Commands.Update;

public class UpdateAttributeGroupMappingCommand : IRequest<CustomResponseDto<UpdatedAttributeGroupMappingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint AttributeId { get; set; }
    public uint AttributeGroupId { get; set; }
    public int? Position { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupMappingsOperationClaims.Update };

    public class UpdateAttributeGroupMappingCommandHandler : IRequestHandler<UpdateAttributeGroupMappingCommand, CustomResponseDto<UpdatedAttributeGroupMappingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
        private readonly AttributeGroupMappingBusinessRules _attributeGroupMappingBusinessRules;

        public UpdateAttributeGroupMappingCommandHandler(IMapper mapper, IAttributeGroupMappingRepository attributeGroupMappingRepository,
                                         AttributeGroupMappingBusinessRules attributeGroupMappingBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupMappingRepository = attributeGroupMappingRepository;
            _attributeGroupMappingBusinessRules = attributeGroupMappingBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeGroupMappingResponse>> Handle(UpdateAttributeGroupMappingCommand request, CancellationToken cancellationToken)
        {
            AttributeGroupMapping? attributeGroupMapping = await _attributeGroupMappingRepository.GetAsync(predicate: agm => agm.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupMappingBusinessRules.AttributeGroupMappingShouldExistWhenSelected(attributeGroupMapping);
            attributeGroupMapping = _mapper.Map(request, attributeGroupMapping);

            await _attributeGroupMappingRepository.UpdateAsync(attributeGroupMapping!);

            UpdatedAttributeGroupMappingResponse response = _mapper.Map<UpdatedAttributeGroupMappingResponse>(attributeGroupMapping);

          return CustomResponseDto<UpdatedAttributeGroupMappingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}