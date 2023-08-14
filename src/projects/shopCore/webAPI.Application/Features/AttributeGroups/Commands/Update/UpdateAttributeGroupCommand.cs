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

namespace Application.Features.AttributeGroups.Commands.Update;

public class UpdateAttributeGroupCommand : IRequest<CustomResponseDto<UpdatedAttributeGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public bool? IsUserDefined { get; set; }
    public uint AttributeFamilyId { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupsOperationClaims.Update };

    public class UpdateAttributeGroupCommandHandler : IRequestHandler<UpdateAttributeGroupCommand, CustomResponseDto<UpdatedAttributeGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        private readonly AttributeGroupBusinessRules _attributeGroupBusinessRules;

        public UpdateAttributeGroupCommandHandler(IMapper mapper, IAttributeGroupRepository attributeGroupRepository,
                                         AttributeGroupBusinessRules attributeGroupBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupRepository = attributeGroupRepository;
            _attributeGroupBusinessRules = attributeGroupBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeGroupResponse>> Handle(UpdateAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            AttributeGroup? attributeGroup = await _attributeGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupBusinessRules.AttributeGroupShouldExistWhenSelected(attributeGroup);
            attributeGroup = _mapper.Map(request, attributeGroup);

            await _attributeGroupRepository.UpdateAsync(attributeGroup!);

            UpdatedAttributeGroupResponse response = _mapper.Map<UpdatedAttributeGroupResponse>(attributeGroup);

          return CustomResponseDto<UpdatedAttributeGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}