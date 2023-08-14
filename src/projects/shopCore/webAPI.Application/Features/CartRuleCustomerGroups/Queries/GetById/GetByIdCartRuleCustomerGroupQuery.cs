using Application.Features.CartRuleCustomerGroups.Constants;
using Application.Features.CartRuleCustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleCustomerGroups.Constants.CartRuleCustomerGroupsOperationClaims;

namespace Application.Features.CartRuleCustomerGroups.Queries.GetById;

public class GetByIdCartRuleCustomerGroupQuery : IRequest<CustomResponseDto<GetByIdCartRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleCustomerGroupQueryHandler : IRequestHandler<GetByIdCartRuleCustomerGroupQuery, CustomResponseDto<GetByIdCartRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
        private readonly CartRuleCustomerGroupBusinessRules _cartRuleCustomerGroupBusinessRules;

        public GetByIdCartRuleCustomerGroupQueryHandler(IMapper mapper, ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository, CartRuleCustomerGroupBusinessRules cartRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
            _cartRuleCustomerGroupBusinessRules = cartRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleCustomerGroupResponse>> Handle(GetByIdCartRuleCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            CartRuleCustomerGroup? cartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerGroupBusinessRules.CartRuleCustomerGroupShouldExistWhenSelected(cartRuleCustomerGroup);

            GetByIdCartRuleCustomerGroupResponse response = _mapper.Map<GetByIdCartRuleCustomerGroupResponse>(cartRuleCustomerGroup);

          return CustomResponseDto<GetByIdCartRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}