using Application.Features.CartRules.Constants;
using Application.Features.CartRules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRules.Constants.CartRulesOperationClaims;

namespace Application.Features.CartRules.Commands.Update;

public class UpdateCartRuleCommand : IRequest<CustomResponseDto<UpdatedCartRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool Status { get; set; }
    public int CouponType { get; set; }
    public bool UseAutoGeneration { get; set; }
    public int UsagePerCustomer { get; set; }
    public int UsesPerCoupon { get; set; }
    public uint TimesUsed { get; set; }
    public bool? ConditionType { get; set; }
    public string? Conditions { get; set; }
    public bool EndOtherRules { get; set; }
    public bool UsesAttributeConditions { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public int DiscountQuantity { get; set; }
    public string DiscountStep { get; set; }
    public bool ApplyToShipping { get; set; }
    public bool FreeShipping { get; set; }
    public uint SortOrder { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRulesOperationClaims.Update };

    public class UpdateCartRuleCommandHandler : IRequestHandler<UpdateCartRuleCommand, CustomResponseDto<UpdatedCartRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleRepository _cartRuleRepository;
        private readonly CartRuleBusinessRules _cartRuleBusinessRules;

        public UpdateCartRuleCommandHandler(IMapper mapper, ICartRuleRepository cartRuleRepository,
                                         CartRuleBusinessRules cartRuleBusinessRules)
        {
            _mapper = mapper;
            _cartRuleRepository = cartRuleRepository;
            _cartRuleBusinessRules = cartRuleBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleResponse>> Handle(UpdateCartRuleCommand request, CancellationToken cancellationToken)
        {
            CartRule? cartRule = await _cartRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleBusinessRules.CartRuleShouldExistWhenSelected(cartRule);
            cartRule = _mapper.Map(request, cartRule);

            await _cartRuleRepository.UpdateAsync(cartRule!);

            UpdatedCartRuleResponse response = _mapper.Map<UpdatedCartRuleResponse>(cartRule);

          return CustomResponseDto<UpdatedCartRuleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}