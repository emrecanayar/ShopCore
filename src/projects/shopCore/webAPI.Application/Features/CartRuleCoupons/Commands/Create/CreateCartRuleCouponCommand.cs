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

namespace Application.Features.CartRuleCoupons.Commands.Create;

public class CreateCartRuleCouponCommand : IRequest<CustomResponseDto<CreatedCartRuleCouponResponse>>, ISecuredRequest
{
    public string? Code { get; set; }
    public uint UsageLimit { get; set; }
    public uint UsagePerCustomer { get; set; }
    public uint TimesUsed { get; set; }
    public uint Type { get; set; }
    public bool IsPrimary { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public uint CartRuleId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCouponsOperationClaims.Create };

    public class CreateCartRuleCouponCommandHandler : IRequestHandler<CreateCartRuleCouponCommand, CustomResponseDto<CreatedCartRuleCouponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
        private readonly CartRuleCouponBusinessRules _cartRuleCouponBusinessRules;

        public CreateCartRuleCouponCommandHandler(IMapper mapper, ICartRuleCouponRepository cartRuleCouponRepository,
                                         CartRuleCouponBusinessRules cartRuleCouponBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponRepository = cartRuleCouponRepository;
            _cartRuleCouponBusinessRules = cartRuleCouponBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleCouponResponse>> Handle(CreateCartRuleCouponCommand request, CancellationToken cancellationToken)
        {
            CartRuleCoupon cartRuleCoupon = _mapper.Map<CartRuleCoupon>(request);

            await _cartRuleCouponRepository.AddAsync(cartRuleCoupon);

            CreatedCartRuleCouponResponse response = _mapper.Map<CreatedCartRuleCouponResponse>(cartRuleCoupon);
         return CustomResponseDto<CreatedCartRuleCouponResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}