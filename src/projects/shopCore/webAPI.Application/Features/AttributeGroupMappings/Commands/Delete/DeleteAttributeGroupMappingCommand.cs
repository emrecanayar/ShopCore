using Application.Features.AttributeGroupMappings.Constants;
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

namespace Application.Features.AttributeGroupMappings.Commands.Delete;

public class DeleteAttributeGroupMappingCommand : IRequest<CustomResponseDto<DeletedAttributeGroupMappingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupMappingsOperationClaims.Delete };

    public class DeleteAttributeGroupMappingCommandHandler : IRequestHandler<DeleteAttributeGroupMappingCommand, CustomResponseDto<DeletedAttributeGroupMappingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
        private readonly AttributeGroupMappingBusinessRules _attributeGroupMappingBusinessRules;

        public DeleteAttributeGroupMappingCommandHandler(IMapper mapper, IAttributeGroupMappingRepository attributeGroupMappingRepository,
                                         AttributeGroupMappingBusinessRules attributeGroupMappingBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupMappingRepository = attributeGroupMappingRepository;
            _attributeGroupMappingBusinessRules = attributeGroupMappingBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeGroupMappingResponse>> Handle(DeleteAttributeGroupMappingCommand request, CancellationToken cancellationToken)
        {
            AttributeGroupMapping? attributeGroupMapping = await _attributeGroupMappingRepository.GetAsync(predicate: agm => agm.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupMappingBusinessRules.AttributeGroupMappingShouldExistWhenSelected(attributeGroupMapping);

            await _attributeGroupMappingRepository.DeleteAsync(attributeGroupMapping!);

            DeletedAttributeGroupMappingResponse response = _mapper.Map<DeletedAttributeGroupMappingResponse>(attributeGroupMapping);

             return CustomResponseDto<DeletedAttributeGroupMappingResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}