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

namespace Application.Features.CartRuleCustomerGroups.Commands.Update;

public class UpdateCartRuleCustomerGroupCommand : IRequest<CustomResponseDto<UpdatedCartRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerGroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomerGroupsOperationClaims.Update };

    public class UpdateCartRuleCustomerGroupCommandHandler : IRequestHandler<UpdateCartRuleCustomerGroupCommand, CustomResponseDto<UpdatedCartRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
        private readonly CartRuleCustomerGroupBusinessRules _cartRuleCustomerGroupBusinessRules;

        public UpdateCartRuleCustomerGroupCommandHandler(IMapper mapper, ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository,
                                         CartRuleCustomerGroupBusinessRules cartRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
            _cartRuleCustomerGroupBusinessRules = cartRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleCustomerGroupResponse>> Handle(UpdateCartRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomerGroup? cartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerGroupBusinessRules.CartRuleCustomerGroupShouldExistWhenSelected(cartRuleCustomerGroup);
            cartRuleCustomerGroup = _mapper.Map(request, cartRuleCustomerGroup);

            await _cartRuleCustomerGroupRepository.UpdateAsync(cartRuleCustomerGroup!);

            UpdatedCartRuleCustomerGroupResponse response = _mapper.Map<UpdatedCartRuleCustomerGroupResponse>(cartRuleCustomerGroup);

          return CustomResponseDto<UpdatedCartRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}