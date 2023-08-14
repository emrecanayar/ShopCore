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

namespace Application.Features.CartRuleCustomerGroups.Commands.Create;

public class CreateCartRuleCustomerGroupCommand : IRequest<CustomResponseDto<CreatedCartRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomerGroupsOperationClaims.Create };

    public class CreateCartRuleCustomerGroupCommandHandler : IRequestHandler<CreateCartRuleCustomerGroupCommand, CustomResponseDto<CreatedCartRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
        private readonly CartRuleCustomerGroupBusinessRules _cartRuleCustomerGroupBusinessRules;

        public CreateCartRuleCustomerGroupCommandHandler(IMapper mapper, ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository,
                                         CartRuleCustomerGroupBusinessRules cartRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
            _cartRuleCustomerGroupBusinessRules = cartRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleCustomerGroupResponse>> Handle(CreateCartRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomerGroup cartRuleCustomerGroup = _mapper.Map<CartRuleCustomerGroup>(request);

            await _cartRuleCustomerGroupRepository.AddAsync(cartRuleCustomerGroup);

            CreatedCartRuleCustomerGroupResponse response = _mapper.Map<CreatedCartRuleCustomerGroupResponse>(cartRuleCustomerGroup);
         return CustomResponseDto<CreatedCartRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}