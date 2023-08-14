using Application.Features.CartRuleCoupons.Constants;
using Application.Features.CartRuleCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleCoupons.Constants.CartRuleCouponsOperationClaims;

namespace Application.Features.CartRuleCoupons.Commands.Update;

public class UpdateCartRuleCouponCommand : IRequest<CustomResponseDto<UpdatedCartRuleCouponResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string? Code { get; set; }
    public uint UsageLimit { get; set; }
    public uint UsagePerCustomer { get; set; }
    public uint TimesUsed { get; set; }
    public uint Type { get; set; }
    public bool IsPrimary { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public uint CartRuleId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCouponsOperationClaims.Update };

    public class UpdateCartRuleCouponCommandHandler : IRequestHandler<UpdateCartRuleCouponCommand, CustomResponseDto<UpdatedCartRuleCouponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
        private readonly CartRuleCouponBusinessRules _cartRuleCouponBusinessRules;

        public UpdateCartRuleCouponCommandHandler(IMapper mapper, ICartRuleCouponRepository cartRuleCouponRepository,
                                         CartRuleCouponBusinessRules cartRuleCouponBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponRepository = cartRuleCouponRepository;
            _cartRuleCouponBusinessRules = cartRuleCouponBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleCouponResponse>> Handle(UpdateCartRuleCouponCommand request, CancellationToken cancellationToken)
        {
            CartRuleCoupon? cartRuleCoupon = await _cartRuleCouponRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponBusinessRules.CartRuleCouponShouldExistWhenSelected(cartRuleCoupon);
            cartRuleCoupon = _mapper.Map(request, cartRuleCoupon);

            await _cartRuleCouponRepository.UpdateAsync(cartRuleCoupon!);

            UpdatedCartRuleCouponResponse response = _mapper.Map<UpdatedCartRuleCouponResponse>(cartRuleCoupon);

          return CustomResponseDto<UpdatedCartRuleCouponResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}