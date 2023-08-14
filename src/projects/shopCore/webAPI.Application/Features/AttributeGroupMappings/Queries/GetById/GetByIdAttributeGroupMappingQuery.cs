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

namespace Application.Features.AttributeGroupMappings.Queries.GetById;

public class GetByIdAttributeGroupMappingQuery : IRequest<CustomResponseDto<GetByIdAttributeGroupMappingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeGroupMappingQueryHandler : IRequestHandler<GetByIdAttributeGroupMappingQuery, CustomResponseDto<GetByIdAttributeGroupMappingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupMappingRepository _attributeGroupMappingRepository;
        private readonly AttributeGroupMappingBusinessRules _attributeGroupMappingBusinessRules;

        public GetByIdAttributeGroupMappingQueryHandler(IMapper mapper, IAttributeGroupMappingRepository attributeGroupMappingRepository, AttributeGroupMappingBusinessRules attributeGroupMappingBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupMappingRepository = attributeGroupMappingRepository;
            _attributeGroupMappingBusinessRules = attributeGroupMappingBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeGroupMappingResponse>> Handle(GetByIdAttributeGroupMappingQuery request, CancellationToken cancellationToken)
        {
            AttributeGroupMapping? attributeGroupMapping = await _attributeGroupMappingRepository.GetAsync(predicate: agm => agm.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupMappingBusinessRules.AttributeGroupMappingShouldExistWhenSelected(attributeGroupMapping);

            GetByIdAttributeGroupMappingResponse response = _mapper.Map<GetByIdAttributeGroupMappingResponse>(attributeGroupMapping);

          return CustomResponseDto<GetByIdAttributeGroupMappingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}