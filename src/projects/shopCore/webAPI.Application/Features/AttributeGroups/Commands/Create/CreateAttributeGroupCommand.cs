using Application.Features.AttributeGroups.Constants;
using Application.Features.AttributeGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeGroups.Constants.AttributeGroupsOperationClaims;

namespace Application.Features.AttributeGroups.Commands.Create;

public class CreateAttributeGroupCommand : IRequest<CustomResponseDto<CreatedAttributeGroupResponse>>, ISecuredRequest
{
    public string Name { get; set; }
    public int Position { get; set; }
    public bool? IsUserDefined { get; set; }
    public uint AttributeFamilyId { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupsOperationClaims.Create };

    public class CreateAttributeGroupCommandHandler : IRequestHandler<CreateAttributeGroupCommand, CustomResponseDto<CreatedAttributeGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        private readonly AttributeGroupBusinessRules _attributeGroupBusinessRules;

        public CreateAttributeGroupCommandHandler(IMapper mapper, IAttributeGroupRepository attributeGroupRepository,
                                         AttributeGroupBusinessRules attributeGroupBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupRepository = attributeGroupRepository;
            _attributeGroupBusinessRules = attributeGroupBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeGroupResponse>> Handle(CreateAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            AttributeGroup attributeGroup = _mapper.Map<AttributeGroup>(request);

            await _attributeGroupRepository.AddAsync(attributeGroup);

            CreatedAttributeGroupResponse response = _mapper.Map<CreatedAttributeGroupResponse>(attributeGroup);
         return CustomResponseDto<CreatedAttributeGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}