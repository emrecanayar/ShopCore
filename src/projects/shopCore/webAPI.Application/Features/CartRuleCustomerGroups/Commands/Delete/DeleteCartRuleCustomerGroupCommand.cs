using Application.Features.CartRuleCustomerGroups.Constants;
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

namespace Application.Features.CartRuleCustomerGroups.Commands.Delete;

public class DeleteCartRuleCustomerGroupCommand : IRequest<CustomResponseDto<DeletedCartRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomerGroupsOperationClaims.Delete };

    public class DeleteCartRuleCustomerGroupCommandHandler : IRequestHandler<DeleteCartRuleCustomerGroupCommand, CustomResponseDto<DeletedCartRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerGroupRepository _cartRuleCustomerGroupRepository;
        private readonly CartRuleCustomerGroupBusinessRules _cartRuleCustomerGroupBusinessRules;

        public DeleteCartRuleCustomerGroupCommandHandler(IMapper mapper, ICartRuleCustomerGroupRepository cartRuleCustomerGroupRepository,
                                         CartRuleCustomerGroupBusinessRules cartRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerGroupRepository = cartRuleCustomerGroupRepository;
            _cartRuleCustomerGroupBusinessRules = cartRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleCustomerGroupResponse>> Handle(DeleteCartRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomerGroup? cartRuleCustomerGroup = await _cartRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerGroupBusinessRules.CartRuleCustomerGroupShouldExistWhenSelected(cartRuleCustomerGroup);

            await _cartRuleCustomerGroupRepository.DeleteAsync(cartRuleCustomerGroup!);

            DeletedCartRuleCustomerGroupResponse response = _mapper.Map<DeletedCartRuleCustomerGroupResponse>(cartRuleCustomerGroup);

             return CustomResponseDto<DeletedCartRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}