using Application.Features.AttributeGroups.Constants;
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

namespace Application.Features.AttributeGroups.Commands.Delete;

public class DeleteAttributeGroupCommand : IRequest<CustomResponseDto<DeletedAttributeGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeGroupsOperationClaims.Delete };

    public class DeleteAttributeGroupCommandHandler : IRequestHandler<DeleteAttributeGroupCommand, CustomResponseDto<DeletedAttributeGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        private readonly AttributeGroupBusinessRules _attributeGroupBusinessRules;

        public DeleteAttributeGroupCommandHandler(IMapper mapper, IAttributeGroupRepository attributeGroupRepository,
                                         AttributeGroupBusinessRules attributeGroupBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupRepository = attributeGroupRepository;
            _attributeGroupBusinessRules = attributeGroupBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeGroupResponse>> Handle(DeleteAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            AttributeGroup? attributeGroup = await _attributeGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupBusinessRules.AttributeGroupShouldExistWhenSelected(attributeGroup);

            await _attributeGroupRepository.DeleteAsync(attributeGroup!);

            DeletedAttributeGroupResponse response = _mapper.Map<DeletedAttributeGroupResponse>(attributeGroup);

             return CustomResponseDto<DeletedAttributeGroupResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}