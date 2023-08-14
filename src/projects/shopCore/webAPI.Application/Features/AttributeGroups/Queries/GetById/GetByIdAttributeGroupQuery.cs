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

namespace Application.Features.AttributeGroups.Queries.GetById;

public class GetByIdAttributeGroupQuery : IRequest<CustomResponseDto<GetByIdAttributeGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeGroupQueryHandler : IRequestHandler<GetByIdAttributeGroupQuery, CustomResponseDto<GetByIdAttributeGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        private readonly AttributeGroupBusinessRules _attributeGroupBusinessRules;

        public GetByIdAttributeGroupQueryHandler(IMapper mapper, IAttributeGroupRepository attributeGroupRepository, AttributeGroupBusinessRules attributeGroupBusinessRules)
        {
            _mapper = mapper;
            _attributeGroupRepository = attributeGroupRepository;
            _attributeGroupBusinessRules = attributeGroupBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeGroupResponse>> Handle(GetByIdAttributeGroupQuery request, CancellationToken cancellationToken)
        {
            AttributeGroup? attributeGroup = await _attributeGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeGroupBusinessRules.AttributeGroupShouldExistWhenSelected(attributeGroup);

            GetByIdAttributeGroupResponse response = _mapper.Map<GetByIdAttributeGroupResponse>(attributeGroup);

          return CustomResponseDto<GetByIdAttributeGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}